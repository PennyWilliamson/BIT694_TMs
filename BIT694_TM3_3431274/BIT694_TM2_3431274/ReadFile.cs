using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Code7248.word_reader; 
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using CSharpJExcel;
using CSharpJExcel.Jxl;
using System.Collections;

namespace BIT694_TM2_3431274
{
    /*
     * Class for reading file formats
     * 
     * Third party libraries:
     * 
     * asubach, a. ,.-a. (2017, September 13). 
     * iTextShap a .Net pdf library. 
     * Retrieved September 20, 2017, 
     * from SourceForge.net: http://sourceforge.net/projects/itextsharp/ ,
     * 
     * code7248, t. (2012, September 26). 
     * Code7248.word_reader. 
     * Retrieved September 20, 2017, 
     * from SourceForge.net: https://sourceforge.net/projects/word-reader/ ,
     * 
     *  grimholtz, l. (2012, October 08). 
     *  A Java library for reading/writing Excel. 
     *  Retrieved September 20, 2017, 
     *  from SourceForge.net: https://sourceforge.net/projects/jexcelapi/
     */
    static class ReadFile
    {

        /*
         * Determines file extension of file, and sends it to
         * appropiate method. And returns output to invertedIndex()
         * 
         * @param string file (filepath)
         * @return string[] 
         */
        static public string[] Read(string file)
        {
            string[] words = null;
            try//catches any files that cannot be opened.
            {
                string ext = System.IO.Path.GetExtension(file);
                //gets file extension
                if (ext == ".txt" || ext == "")
                {
                    words = ReadTxt(file);
                }

                if (ext == ".doc")
                {
                    words = ReadDoc(file);
                }

                if (ext == ".pdf")
                {
                    words = ReadPdf(file);
                }

                if (ext == ".xls")
                {
                    words = ReadXls(file);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err);
            }
            return words;
        }

        /*
         * Reads text files using StreamReader
         * @param string file (filepath)
         * @return string[]
         */
        static private string[] ReadTxt(string file)
        {
            string[] words = null;//sets a new array
            try //caches StreamReader errors
            {
                String line;//variable to hold output from StreamReader
                TextReader tr = new StreamReader(file);//reads the file
                while ((line = tr.ReadLine()) != null)//fires if line is not null
                {
                    if (!line.Contains("X-FileName") || !line.Contains("Message-ID:") || !line.Contains("To:"))
                        //removes some headers
                    {
                        words = SetArray(line, file);//sets words to return from method 
                    }
                }
                tr.Close();//closes the stream reader
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err);

            }
            return words;//returns array to read() method
        }

        /*
         * Reads .doc files
         * Useage patterns from (code7248, 2012)
         * @param string file (filepath)
         * @return string[]
         */
        static private string[] ReadDoc(string file)
        {
            string[] words = null;//sets new array
            try
            {
                TextExtractor te = new TextExtractor(file);//readers text 
                string line = te.ExtractText();//sets string to read line
                words = SetArray(line, file);//sets array to line read
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err);
            }
            return words;//returns array to read() method
        }

        /*
         * reads .pdf files.
         * Useage patterns from (asubach, 2017)
         * @param string file (filepath)
         * @return string[]
         */
        static private string[] ReadPdf(string file)
        {
            string[] words = null;//sets new array
            try
            {
                StringBuilder line = new StringBuilder();//stringbuilder object to hold text
                using (PdfReader read = new PdfReader(file))//pdf reader object
                {
                    for (int j = 1; j <= read.NumberOfPages; j++)//iterates over pages
                    {
                        line.Append(PdfTextExtractor.GetTextFromPage(read, j));
                    }//adds page to line
                    read.Close();//clese pdf reader
                }
                words = SetArray(line.ToString(), file);//sets array to return from method
                
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err);
            }
            return words;//returns array to read() method
        }

        /*
         * Reads .xls files
         * Useage patterns from (grimholtz, 2012)
         * @param string file (filepath)
         * @return string[]
         */
        static private string[] ReadXls(string file)
        {
            string[] words = null;//sets new Array
            string line = "";//sets line to hold contents
            try
            {
                Workbook wrkbk = Workbook.getWorkbook(new System.IO.FileInfo(file));//gets workbook
                for (int i = 0; i < wrkbk.getNumberOfSheets(); i++)//iterate sheets
                {
                    var sheet = wrkbk.getSheet(i); //sets a variable holding current sheet
                    for (int j = 0; j < sheet.getColumns(); j++)//iterate columns
                    {
                        for (int k = 0; k < sheet.getRows(); k++)//iterate rows
                        {
                            var con = sheet.getCell(j, k).getContents();//sets a variable holding a current cell
                            line += con;//adds content of cell onto the string line.
                        }
                    }
                }
                words = SetArray(line, file);//sets array
                wrkbk.close();//closes the workbook
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err);
            }
            return words;//returns word to read() method
        }
        
        /*
         * Sets the arrays for methods.
         * @param string line (the contents of file)
         * @param string file (filepath)
         * @return string[]
         */
        static private string[] SetArray(string line, string file)
        {
            string[] words;//sets new array
            String trimLine = line.Trim();//trims whitespace, /r and /n from start and  end of line. 
            String aLine = Regex.Replace(trimLine, @"[^\w\s _]", "");//removes punctuation, and replaces it with "".
            words = aLine.Split(' ');//sets an array to the line split at spaces.
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != "" || words[i].Length < 50)//fires if word[i] is not "".
                {
                    words[i] = words[i].ToLower();//sets the words to lowercase
                    String wordi = words[i];//sets the String variable wordi to words[i]
                    TermFreq.AddToCollectionFreq(wordi);//adds the word to collectionWordFreq Hashtable.
                }
            }
            return words;//returns words array to method that called SetArray()
        }
    }
}

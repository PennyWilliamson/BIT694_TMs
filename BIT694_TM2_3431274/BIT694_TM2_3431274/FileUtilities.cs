using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIT694_TM2_3431274
{
    class FileUtilities
    {
        private string[] words; //holds the line being read, split at ' '. Declared here, so a new object is not created for every file.
        static private ArrayList output = new ArrayList();//holds the files that match searchTerms or synonyms.
                                                          //Static so it stays in memory, and is not garabage collected 
                                                          //before search is finished. 


        /*
         * Constructor
         */
        public FileUtilities() { }

        /*
         * resets the two static class variables
         * back to empty data collections.
         */
        public void ResetOutput()
        {
            output = new ArrayList();
        }

        /*
         * Recursive method that searches  over directory structure
         * to find the files. Then reads the contents of each file, and 
         * calls addToCollectionFreq() for each word.
         * Calls appropriate FileMatch method for whether 
         * the search is being done with database or without.
         * if true is returned, writeToOutput() is called.
         * @params string dir, Boolean useDataBase, string[] searchTerms,
         * @params List<HashSet<string>> newSearch
         */
        public void SearchDir(string dir, Boolean useDataBase, string[] searchTerms, List<HashSet<string>> newSearch)
        {
            try//handles TextReader and StreamReader errors and non existing-file paths.
            {
                foreach (string file in Directory.GetFiles(dir))//iterates over files in the current directory
                {
                    String line;//variable to hold output from StreamReader 
                    TextReader tr = new StreamReader(file);//reads the file
                    while ((line = tr.ReadLine()) != null)//fires if line is not null
                    {
                        String aLine = Regex.Replace(line, @"[^\w\s]", "");//removes punctuation, and replaces it with "".
                        words = aLine.Split(' ');//sets an array to the line split at spaces.
                        for (int i = 0; i < words.Length; i++)
                        {
                            if (words[i] != "")//fires if word[i] is not "".
                            {
                                words[i] = words[i].ToLower();//sets the words to lowercase
                                String wordi = words[i];//sets the String variable wordi to words[i]
                                TermFreq.AddToCollectionFreq(wordi);//adds the word to collectionWordFreq Hashtable.
                            }
                        }
                    }
                    if (useDataBase)//fires if include synonym checked
                    {
                        if (Search.FileMatchTermDb(words, newSearch))//fires if file contains a search term or its synonym
                        {
                            writeToOutput(file);//Writes filepath to output ArrayList
                        }
                    }
                    else//fires if include synonym unchecked
                    {
                        if (Search.FileMatchTerm(words, searchTerms))//fires if file contains a search term
                        {
                            writeToOutput(file);//Writes filepath to output ArrayList
                        }
                    }
                }
                foreach (string dirs in Directory.GetDirectories(dir))//iterates through dirctories in directory structure.
                {
                    SearchDir(dirs, useDataBase, searchTerms, newSearch);//calls its self, so files in next directory can be searched.
                }

            }
            catch (Exception err)//catches TextReader and StreamReader errors
            {
                MessageBox.Show("" + err);
            }
        }

        /*
         * Adds the filepath string
         * to output.
         * @param string file
         * @return output
         */
        public ArrayList writeToOutput(string file)
        {
            output.Add(file);
            return output;
        }

        /*
         * Getter so output can be used in Form1.cs
         * @return output
         */
        public ArrayList getOutput
        {
            get { return output; }
        }

    }
}

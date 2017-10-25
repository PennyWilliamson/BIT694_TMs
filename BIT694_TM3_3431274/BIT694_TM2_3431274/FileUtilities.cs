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
        static readonly object _lock = new object();//used for multi threading
        private ArrayList filePath = new ArrayList();
        //ArrayList to hold file paths to be read. Set here, as method iterates






        /*
         * Constructor
         */
        public FileUtilities() { }



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
        public void SearchDir(string dir)
        {
            try//handles TextReader and StreamReader errors and non existing-file paths.
            {
                foreach (string file in Directory.GetFiles(dir))//iterates over files in the current directory
                {
                    lock (_lock)
                    //method locked so only one thread can access at a time.
                    //Locked here as to avoid problems with same file being accessed.
                    {
                        filePath.Add(file);//adds file path to ArrayList

                    }
                }

                foreach (string dirs in Directory.GetDirectories(dir))//iterates through dirctories in directory structure.
                {
                    SearchDir(dirs);//calls its self, so files in next directory can be searched.
                }

            }
            catch (Exception err)//catches TextReader and StreamReader errors
            {
                MessageBox.Show("" + err);
            }
        }

        /*
         * Calls searchDir for InvertedIndex.
         * 
         * @param string dir (starting file path)
         * @return ArrayList filepath
         */
        public ArrayList Search(string dir)
        {
            SearchDir(dir);
            return filePath;
        }


    }
}

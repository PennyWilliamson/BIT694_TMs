using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIT694_TM2_3431274
{
    class InvertedIndex
    {
        static internal Hashtable invertedIndex = new Hashtable();//internal so it can be accessed from other classes
        //static so they are not garbage collected
        static private List<string> stopList;//holds stop list
        static readonly object _lock = new object();//for multi threading
        private ArrayList filePath; //arraylist for holding file paths
        private Converter convert; //constructor for convert class

        public InvertedIndex()
        {
            convert = new Converter();
            //new convert class object.
        }

        /*
         * Resets data structures for rebuild
         */
        public void ResetInvertedIndex()
        {
            invertedIndex.Clear();// clears contents of invertedIndex
            TermFreq.ResetFreq();//resets collectionWordsFreq
        }

        /*
         * Builds an inverted index, with fileIds from Converter class.
         * @param string dir (starting filepath)
         * @return Hashtable invertedIndex
         */
        public Hashtable BuildInvertedIndex(string dir)
        {
            FileUtilities fileUtil = new FileUtilities();//constructor so fileUtiltes can be called
            filePath = new ArrayList();//new ArrayList
            filePath = fileUtil.Search(dir);//sets filePath to return from Search() method

            lock (_lock)
            //method locked so only one thread can access at a time.
            {
                foreach (string file in filePath)//interates over filePath
                {
                    string[] words = ReadFile.Read(file);//sets array to return from Read() method
                    int fileID = convert.AssignId(file);//sets fileId int to return from assignId()
                    Dictionary<int, int> d = new Dictionary<int, int>(); //new dictionary 
                    //Internal dictionary. fileID, count number of times word in file (for sort)
                    var pStemmer = new PorterStemmer();//sets a variable to call PorterStemmer
                    for (int i = 0; i < words.Length; i++)//iterates over file contents
                    {
                        string wordi = words[i];//sets a string to index i of word.
                        var pStemWord = "";//sets stem word variable.
                        if (!stopList.Contains(wordi))//checks wordi is not in stopList
                        {
                            pStemWord = pStemmer.StemWord(wordi);//stems word
                        }

                        if (invertedIndex.ContainsKey(pStemWord))//fires if collection already contains word.
                        {
                            try //handles parse errors
                            {
                                d = (Dictionary<int, int>)invertedIndex[pStemWord];
                                //gets dictionary for pStemWord
                                if (d.Keys.Contains(fileID))//checks to see if fileId is already in dictionary
                                {
                                    int v = d[fileID] + 1;//sets frequency to frequency plus 1
                                    d[fileID] = v;//changes frequency
                                }
                                else
                                {
                                    d.Add(fileID, 1); 
                                    //adds fileID and frequency 1 to dictionary, if fileId not already in dictionary.
                                }
                            }
                            catch (Exception err) //catches parse errors
                            {
                                MessageBox.Show("" + err);
                            }
                        }
                        else//fires if word not present in index.
                        {
                            d = new Dictionary<int, int>();//sets new dictioanry to add
                            d.Add(fileID, 1);//adds fileId and a frequency of 1 to dictionary
                            invertedIndex.Add(pStemWord, d);//adds word and dictionary to Hashtable.
                        }
                    }
                }
                return invertedIndex;//returns Hashtable
            }
        }

        /*
         * Sorts the output of searches by frequency, with highest first,
         * so they can be output on form.
         * Here as it accesses filepath names from Convert class.
         * @return Dictionary<string, int>
         */
        public Dictionary<string, int> WriteToOutput()
        {
            Dictionary<string, int> output = new Dictionary<string, int>();//new dictionary
            Dictionary<int, int> file = Search.fp;//dictionary set to fp from search
            SortedList<string, int> paths = new SortedList<string, int>();//For sorting by value
            foreach (int id in file.Keys)//iterates over keys
            {
                int termCount = file[id]; //gets the frequency count
                paths.Add(convert.GetPath(id), termCount);//adds filpath and frequency to sorted list
            }
            output = paths.OrderByDescending(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            // sets out put to result of sorting list by values, then setting it to a dictionary.
            return output;//returns output to form method.
        }



        /*
         * A stop list of common words and common words from files.
         * Used to improve inverted index.
         */
        public void StopWords()
        {
            stopList = new List<string>();//sets new stop list
            stopList.Add("the");
            stopList.Add("be");
            stopList.Add("to");
            stopList.Add("of");
            stopList.Add("and");
            stopList.Add("a");
            stopList.Add("in");
            stopList.Add("that");
            stopList.Add("have");
            stopList.Add("I");
            stopList.Add("because");
            stopList.Add("was");
            stopList.Add("is");
            stopList.Add("are");
            stopList.Add("always");
            stopList.Add("85663781075852814876javamailevansthyme 1");
            stopList.Add("101014 2");
            stopList.Add("brbra 7");
            stopList.Add("uhmain 13");
            stopList.Add("thackermajestic 55");
            stopList.Add("rodgers 98");
            stopList.Add("city 5119");
            stopList.Add("in 256590");
            stopList.Add(" 4452640");

        }

    }
}

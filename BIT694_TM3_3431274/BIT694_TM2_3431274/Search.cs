using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIT694_TM2_3431274
{
    static class Search
    {
        /*
         * Static as it has no class variables.
         * A static class to handle searching the contents of
         * files and matching them to term or term and synonym.
         */
        static internal Dictionary<int, int> fp;
        //Holds fileIds and frequency for output
        //internal so InvertedIndex can access it.
      


        /*
         * Called when Include Synonyms is unchecked.
         * Matches the contents of inverted index to the 
         * search terms. 
         * @param string[] searchTerms 
         */
        static public void IndexedFileMatchTerm(string[] searchTerms)
        {
            fp = new Dictionary<int, int>(); //Dictionary for holding filepaths in loop. 
            Dictionary<int, int> d = new Dictionary<int, int>();
            //Sets up a collection of the keys of InvertedIndex hashtable for searching.
            var pStemmer = new PorterStemmer();//sets a variable to call PorterStemmer
            for (int i = 0; i < searchTerms.Length; i++)//iterates over searchTerms
            {
                var pStemSearchTerm = pStemmer.StemWord(searchTerms[i].ToLower());
                //stems the search term.
                foreach (string word in InvertedIndex.invertedIndex.Keys)//iterates over collection of keys
                {
                    if (word == pStemSearchTerm)//fires if current key equals search term.
                    {

                        d = new Dictionary<int, int>();
                        d = (Dictionary<int, int>)InvertedIndex.invertedIndex[word];
                        //sets a dictionary variable for the values of the key 'word'

                        if (searchTerms[0] == searchTerms[i])//Fires on first run to populate fp.
                        {
                            foreach (int key in d.Keys)//iterates over keys of current dictionary
                            {
                                int h = d[key];//gets frequency of key for term
                                fp.Add(key, h);//adds key and frequency to fp
                            }

                        }

                        if (i > 0)
                         //fires on second and subsequent runs to restrict fp to ids that contain all terms
                        {
                            List<int> fpKey = fp.Keys.ToList();
                            //sets a list to fp keys, as fp is changed in loop.
                            foreach (int id in fpKey)//iterates over list
                            {

                                if (!d.Keys.Contains(id))
                                //fires if current dictionary key does not match any ids in fpKeys
                                {
                                    fp.Remove(id);//removes id from fp
                                }

                                if (d.Keys.Contains(id))//fires if fpKeys contains current dictionary key.
                                {
                                    int j = d[id];//gets frequency of key for term
                                    int k = fp[id];//gets frequency of fp id for term
                                    int v = j + k;//adds frequencies together
                                    fp[id] = v;//changes frequency of id to new frequency
                                }
                            }
                        }
                    }
                }
            }
        }



        /*
         * Called when Include Synonyms is checked.
         * Matches the contents of inverted index to the 
         * search terms and synonyms. 
         * @param List<HashSet<string>> newSearch
         */
        static public void IndexedFileMatchTermDb(List<HashSet<string>> newSearch)
        {
            fp = new Dictionary<int, int>(); //Dictionary for holding filepaths in loop. 
            Dictionary<int, int> d = new Dictionary<int, int>();
            Dictionary<int, int> hold;
            //Sets up a collection of the keys of InvertedIndex hashtable for searching.
            for (int i = 0; i < newSearch.Count; i++)//iterates over newSearch
            {
                hold = new Dictionary<int, int>();
                //newSearch stemmed in DBUtilities SearchWithDB()
                foreach (string word in InvertedIndex.invertedIndex.Keys)//iterates over collection of keys
                {
                    if (newSearch[i].Contains(word))//fires if newSearch contains the current key.
                    {
                        d = new Dictionary<int, int>();
                        d = (Dictionary<int, int>)InvertedIndex.invertedIndex[word];
                        //sets a dictionary variable for the values of the key 'word'

                        if (newSearch[0] == newSearch[i])//Fires on first run to populate fp.
                        {
                            foreach (int key in d.Keys)//iterates over keys of current dictionary
                            {
                                if (!fp.Keys.Contains(key))
                                {
                                    int h = d[key];//gets frequency of key for term
                                    fp.Add(key, h);//adds key and frequency to fp
                                }
                                else
                                {
                                   int j = d[key];//gets frequency of dictionary key for term
                                    int k = fp[key];//gets frequency of fp id for term
                                    int v = j + k;//Adds frequenies together.
                                    hold[key] = v;//changes frequency of id to new frequency
                                }
                            }
                        }
                        }

                        if (i > 0)
                            //fires on second and subsequent runs to set dictionary of all file ids and 
                            //frequencies of a term and its synonyms
                        {
                            
                            List<int> dKey = d.Keys.ToList();
                            //sets a list to fp keys, as fp is changed in loop.
                            foreach (int key in d.Keys)
                            {
                                if (!hold.Keys.Contains(key))
                                //fires if current dictionary key does not match any ids in fpKeys
                                {
                                    int h = d[key];
                                    hold.Add(key, h);
                                }
                                if (hold.Keys.Contains(key))//fires if fpKeys contains current dictionary key.
                                {
                                    int j = d[key];//gets frequency of dictionary key for term
                                    int k = hold[key];//gets frequency of fp id for term
                                    int v = j + k;//Adds frequenies together.
                                    hold[key] = v;//changes frequency of id to new frequency
                                }
                            }
                            
                        }
                    }
                if (i > 0)//fires only after hold has been populated, on second and subsequent runs
                {
                    List<int> fpKey = fp.Keys.ToList();
                    List<int> holdKey = hold.Keys.ToList();
                    //sets a list to fp keys, as fp is changed in loop.
                    foreach (int id in fpKey)
                    {

                        if (!holdKey.Contains(id))
                        //fires if current dictionary key does not match any ids in fpKeys
                        {
                            fp.Remove(id);
                        }
                        if (holdKey.Contains(id))//fires if fpKeys contains current dictionary key.
                        {
                            int j = hold[id];//gets frequency of dictionary key for term
                            int k = fp[id];//gets frequency of fp id for term
                            int v = j + k;//Adds frequenies together.
                            fp[id] = v;//changes frequency of id to new frequency
                        }
                    }
                }
            }


          
        }


        //***TM2 code, not used in TM3*********************************
        /*
* Called when Include Synonyms is unchecked.
* Matches the contents of a file to the 
* search terms. Returns contains if all the
* terms are matched.
* @param string[] aFile, string[] searchTerms
* @return Boolean contains
*/
        static public Boolean FileMatchTerm(string[] aFile, string[] searchTerms)
        {
            bool[] containsTerms = new bool[searchTerms.Length];//Boolean array set to length of passed in searchTerms.
            Boolean contains = false;//Boolean variable for return value.
            var pStemmer = new PorterStemmer();//sets a variable to call PorterStemmer
            for (int i = 0; i < searchTerms.Length; i++)//iterates over searchTerms
            {
                var pStemSearchTerm = pStemmer.StemWord(searchTerms[i].ToLower()); //stems the search term.
                foreach (string aWord in aFile)//iterates over passed in aFile
                {
                    var pStemWord = pStemmer.StemWord(aWord); //stems the word being matched.
                    if (pStemWord == pStemSearchTerm)//fires if StemWordWord matches search term currently being iterated. 
                    {
                        containsTerms[i] = true;//sets Boolean for that term to true.
                    }
                }
            }

            if (containsTerms.All(x => x))//fires if file contains all search terms.
            {
                contains = true;//sets return variable to true
            }

            return contains;//returns Boolean.
        }

        /*
         * Called when Include Synonyms is checked.
         * Matches the contents of a file to the 
         * search terms and synonyms. Returns contains if all the
         * terms or their synonyms are matched.
         * @param string[] aFile, List<HashSet<string>> newSearch
         * @return Boolean contains
         */
        static public Boolean FileMatchTermDb(string[] aFile, List<HashSet<string>> newSearch)
        {
            Boolean contains = false;//Boolean variable for return value
            bool[] containsTerms = new bool[newSearch.Count];//Boolean array set to length of passed in newSearch.
            var pStemmer = new PorterStemmer(); //sets a variable to call PorterStemmer
            for (int i = 0; i < newSearch.Count; i++)//iterates over newSearch
            {
                //newSearch stemmed in DBUtilities SearchWithDB()
                foreach (string aWord in aFile)//fires if aWord contains term currently being iterated.
                {
                    var pStemWord = pStemmer.StemWord(aWord);
                    if (newSearch[i].Contains(pStemWord))//fires if aWord contains term currently being iterated.
                    {
                        containsTerms[i] = true;//sets Boolean for that term to true
                    }
                }
            }

            if (containsTerms.All(x => x))//fires if file contains a search term or its' synonym.
            {
                contains = true;//sets return variable to true
            }
            return contains;//returns Boolean.
        }
    }

}





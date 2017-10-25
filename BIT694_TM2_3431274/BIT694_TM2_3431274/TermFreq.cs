using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIT694_TM2_3431274
{
    static class TermFreq
    {
        /*
         * Static as the ony class variable is static.
         * Static class for adding words from files to 
         * Hashtable collectionWordsFreq.
         * And iterating over collectionWordsFreq 
         * for query term frequency and most common word.
         */
        static private Hashtable collectionWordsFreq = new Hashtable();
        //static varible to hold collectionTermsFreq in memory.
        //Initilized here as AddToCollectionFreq is called for every word in a file.


        /*
         * Sets collectionWordsFreq to a new
         * instance of Hashtable. Allows a new
         * search to have an empty dataset.
         */
        static public void ResetFreq()
        {
            collectionWordsFreq = new Hashtable();
        }

        /*
         * Adds a word to collectionWordsFeq if it is not
         * already present, and sets frequency to one.
         * Otherwise increases frequency of word by one.
         * @param String wordi
         * @return Hashtable collectionWordsFreq
         */
        static public Hashtable AddToCollectionFreq(String wordi)
        {
            if (collectionWordsFreq.ContainsKey(wordi))//fires if collection already contains word.
            {
                try //handles parse errors
                {
                    collectionWordsFreq[wordi] = double.Parse(collectionWordsFreq[wordi].ToString()) + 1;
                    // increases frequency by one. 
                }
                catch (Exception err) //catches parse errors
                {
                    MessageBox.Show("" + err);
                }
            }
            else//fires if word not present.
            {
                collectionWordsFreq.Add(wordi, 1);//adds word and frequency of 1 to Hashtable.
            }
            return collectionWordsFreq;//returns Hashtable
        }

        /*
         * Works out the most common word found in files.
         * @return string mostCommon
         */
        static public string CollectionFreq()
        {
            string[] common = new string[1];//holds most common term for collection frequency
            int freq = 0;//holds current highest frequency value
            int i = 0;//holds value for array position

            foreach (String p in collectionWordsFreq.Keys)//iterates over collectionWordsFreq uing the keys (words)
            {
                try //handles parse errors
                {
                    int val = int.Parse(collectionWordsFreq[p].ToString());//sets value to the value of key frequency

                    if (val > freq)//fires if frequency of word is higher than current highest frequency.
                    {
                        if (p != "")//fires only if word is not a line return or other null value.
                        {
                            common[i] = p + " " + collectionWordsFreq[p];//adds word and frequency
                            i = i + 1;//increase i by 1.
                            freq = val;//sets freq to new highest val.
                        }
                        if (i == 1)//fires if i = 1
                        {
                            i = 0;//sets i back to 0.
                        }
                    }
                }
                catch (Exception err)//catches parse errors
                {
                    MessageBox.Show("" + err);
                }
            }
            string mostCommon = common[0];//sets string mostCommon to value of common[0]
            return mostCommon;//returns string.
        }

        /*
         * Uses collectionWordsFreq to work out the frequency
         * of query terms in the files.
         * @param string[] searchTerms
         * @return string terms.
         */
        static public string QueryTermFreq(string[] searchTerms)
        {
            string terms = "";//sets string for return.
            foreach (String s in searchTerms)//iterates over searchTerms
            {
                foreach (String t in collectionWordsFreq.Keys)//iterates over collection freq
                {
                    if (s == t)//fires if key in collectionWordsFreq equals current searchTerm(s)
                    {
                        terms += t + " " + collectionWordsFreq[t].ToString() + "\r\n";
                        //Adds word and frequency, followed by a new line to string terms
                    }
                }
            }
            return terms;//returns string.
        }
    }
}

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
         * A ststic class to handle searching the contents of
         * files and matching them to term or term and synonym.
         */


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
            for (int i = 0; i < searchTerms.Length; i++)//iterates over searchTerms
            {
                foreach (string aWord in aFile)//iterates over passed in aFile
                {
                    if (aWord == searchTerms[i].ToString())//fires if aWord contains search term currently being iterated. 
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
            for (int i = 0; i < newSearch.Count; i++)//iterates over newSearch
            {
                foreach (string aWord in aFile)//fires if aWord contains term currently being iterated.
                {
                    if (newSearch[i].Contains(aWord))//fires if aWord contains term currently being iterated.
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

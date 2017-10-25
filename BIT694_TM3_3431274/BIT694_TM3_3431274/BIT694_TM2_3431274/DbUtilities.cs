using BIT694_TM2_3431274.NewWordsFullDataSetTableAdapters;
//Allows me to use wordTableAdapters to update the table.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

/*
 * The class for methods that call the database,
 * or use the database.
 */
namespace BIT694_TM2_3431274
{
    class DbUtilities
    {
        private NewWordsFullDataSet newWordsFullDataSet; //dataset variable for class use.

        /*
        * Construtor. Takes in the dataset
        * newWorldsFullDataSet. Allows it to be
        * used by methods, without having to pass
        * it in the method signature.
        * @param NewWordsFullDataSet ds
        */
        public DbUtilities(NewWordsFullDataSet ds) { this.newWordsFullDataSet = ds; }


        /*
         * Public, so it can be called from Form1.cs.
         * Searches the database for the synonyms of
         * the search terms. Creates an List of HashSet's of the search
         * terms and their synonyms.
         * @params searchTerms array and newWordsFullDataSet
         * @returns List<HashSet<string>> newSearch.
         */
        public List<HashSet<string>> SearchWithDb(string[] searchTerms)
        {
            var pStemmer = new PorterStemmer();//sets a variable to call PorterStemmer.
            //Stemmed here as it is easier than stemming the HashSet<string> in Search class.
            List<HashSet<string>> newSearch = new List<HashSet<string>>();
            //initialises and declares the List of HashSets to hold searchTerms and their synonyms. 
            //Returned at end of method.
            try//handles database call errors.
            {
                foreach (string s in searchTerms) //iterates over passed in searchTerm array
                {
                    HashSet<string> term = new HashSet<string>();//HashSet to add to List
                    var pStemS = pStemmer.StemWord(s); //stems the search term.
                    term.Add(pStemS);//Adds the stemmed searchTerm pStemS to HashSet.
                    NewWordsFullDataSet.WordsRow wordsRow = newWordsFullDataSet.Words.FindByWord(s);
                    //gets the row with s as index                   
                    if (wordsRow != null)//checks that a row is retrieved.
                    {
                        string[] synList = wordsRow.Synonyms.ToString().Split(',');//splits the word row at , and stores them in an array.
                        for (int j = 0; j < synList.Length; j++)//iterates over the synonyms array, length - 1 times.
                        {
                            var pStemSyn = pStemmer.StemWord(synList[j]); //stems the synonym.
                            term.Add(pStemSyn);//Adds the stemmed synonym to the term HashSet.
                        }
                    }
                        newSearch.Add(term);//Adds the HashSet to the List
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("" + err);
            }
            return newSearch; //returns the List<HashSet<string>> containing searchTerms and their synonyms.
        }

        /*
         * Public so it can be called from Form1.cs.
         * Adds the passed in word, and its passed in
         * synonyms to the database.
         * @params word, syn and newWordsFullDataSet.
         */
        public void AddWord(String word, String syn)
        {
            try//handles database call errors
            {
                DataRow newRow = newWordsFullDataSet.Tables["Words"].NewRow();//local variable containing a blank row for words table.
                newRow["Word"] = word;//sets the Word column in newRow to passed in word variable.
                newRow["Synonyms"] = syn;//sets the Synonyms column in newRow to passed in syn variable.
                newWordsFullDataSet.Tables["Words"].Rows.Add(newRow);//adds newRow to the dataSet in memory.
                WordsTableAdapter wordsTableAdapter = new WordsTableAdapter();//creates an instance of TableAdapter
                wordsTableAdapter.Update(newWordsFullDataSet);//Adds the new row to the database table Words.
                MessageBox.Show(word + " and synonyms added to database");
            }
            catch (Exception err)
            {
                MessageBox.Show("" + err);
            }
        }

        /*
         * Public so it can be called from Form1.cs
         * Deletes the row the passed in varaible
         * delWord indexes, from the database.
         * @params delWord, newWordsFullDataSet.
         */
        public void DeleteWord(String delWord)
        {
            try//handles database errors
            {
                NewWordsFullDataSet.WordsRow wordsRow = newWordsFullDataSet.Words.FindByWord(delWord);
                if (wordsRow == null)
                {
                    MessageBox.Show(delWord + " is not in database");
                }
                if (wordsRow != null)
                {
                    //sets dataSet newRow to the row in the dataSet indexed by delWord
                    wordsRow.Delete();//deletes from the dataSet.
                    MessageBox.Show(delWord + " and synonyms deleted");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error occured " + err);
            }
        }

        /*
         * Public so it can be called from Form.cs
         * Updates the synonym list in the DataSet,
         * for the word indexed by passed in variable word,
         * with the passed in variable syn.
         * @params word, syn and newWordsFullDataSet.
         */
        public void UpdateWord(String word, String syn)
        {
            try//handles database errors
            {
                NewWordsFullDataSet.WordsRow wordsRow = newWordsFullDataSet.Words.FindByWord(word);
                if (wordsRow == null)
                {
                    MessageBox.Show(word + " is not in database");
                }
                if (wordsRow != null)
                {
                    //sets wordsRow to the DataSet row indexed by word.
                    wordsRow.Synonyms += "," + syn; //adds to the list of existing synonyms in wordsRow.
                    MessageBox.Show("Synonym added to " + word + " synonym list");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("" + err);
            }
        }

        /*
         * Public so it can be called from Form1.cs.
         * Queries the DataSet for the synonyms indexed by the passed in variable
         * word. Splits the synonym csv and reads it into string array.
         * @params word, newWordsFullDataSet
         * @return string str
         */
        public string Query(string word)
        {
            string str = "";//the string variable that is returned.
            try//handles database errors.
            {
                NewWordsFullDataSet.WordsRow wordsRow = newWordsFullDataSet.Words.FindByWord(word);
                //sets wordsRow to the dataSet row indexed by passed in variable word.
                if (wordsRow == null)
                {
                    MessageBox.Show(word + " is not in database");
                }
                if (wordsRow != null)//fires if word is an index in DataSet. 
                {
                    string[] synList = wordsRow.Synonyms.ToString().Split(',');
                    //sets an Array to the split result for the synonym csv.

                    foreach (string s in synList)//iterates over synList array
                    {
                        str += s + "\r\n";
                        //sets str to a series of string varaibles, that will display on new lines.
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("" + err);
            }
            return str;
            //returns the string of synonyms to be displayed in QuerySynonym textbox.
        }
    }

}


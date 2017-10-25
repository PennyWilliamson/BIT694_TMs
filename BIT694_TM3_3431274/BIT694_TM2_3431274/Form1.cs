 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Threading;

/*
 * Class for handling reading from, writing
 * to and opening from form. 
 * Also handles the time taken for SearchDir() to run.
 * All methods private for encapsulation of GUI.
 */
namespace BIT694_TM2_3431274
{
    public partial class Form1 : Form
    {
        private string[] searchTerms;//holds the search terms entered by user
        private string folderPath;//holds the folder path for the folder selected by user
        private List<HashSet<string>> newSearch;//holds the search terms and their synonyms.
        private int numSearch; //the number of times a new search has occured.
        private long elapsedTime;//holds the time it took SearchDir() to run.
        private long average;//holds the average time it takes for SearchDir() to run
        private long totalTime;//Holds the total time all SearchDir() runs have taken.
        FileUtilities fileUtil = new FileUtilities();//constructor to call methods in FileUtilities class.
        private Boolean rebuild;//holds boolean for second thread running
        private InvertedIndex index;//Declares new instance for Inverted Index class


        public Form1()
        {
            InitializeComponent();

            index = new InvertedIndex();//intializes a new InvertedIndex class object
        }


        /*
         * Brings up a folder browser dialog, allowing
         * user to navigate to and select a folder to
         * search.
         * @param object sender, EventArgs e
         */
        private void SelectBut_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            //sets result to button selected on dialog box
            //displays folder browser window.
            if (result == DialogResult.OK)//fires if a folder is selected and OK pressed.
            {
                folderPath = folderBrowserDialog1.SelectedPath;//sets folderpath to the selected file path.
                SelectFolder.Clear();//sets the textbox to clear
                SelectFolder.Text = folderPath;//sets the textbox to folderpath. 
                index.ResetInvertedIndex();// resets inverted index in memory to a new Hashtable, so it can be built.
                index.StopWords();//builds the stopwords ArrayList
            }
        }



        /*
         * Takes input of file path and search terms.
         * Splits search terms into an array, and if include
         * synonyms is checked, fires method for setting 
         * terms and synonyms (newSearch varible).
         * Calls SearchDirectory, runs timer while that is running,
         * and outputs time taken to form.
         * Fires the method to populate form with returned
         * data.
         * @param object sender, EventArgs e
         */
        private void Searchbut_Click(object sender, EventArgs e)
        {
            if (rebuild)//fires if inverted index is being refreshed
            {
                MessageBox.Show("Currently unavailable. Please try again later");

            }
            else
            {
                if (SelectFolder.Text == "")//error handling for no file path selected
                {
                    MessageBox.Show("Please select a file and try again");
                }
                if (SearchTerms.Text == "")//error handling for no search terms entered.
                {
                    MessageBox.Show("Please a enter a search term, and try again");
                }

                FilePathOutput.Items.Clear();//clears list box.

                if (SearchTerms.Text != "" && SelectFolder.Text != "")//fires if there is a filepath and search term entered.
                {
                    numSearch = numSearch + 1;//adds one to variable holding number of searches. Used for average time.
                    searchTerms = SearchTerms.Text.Split(',', ' ');//splits the search terms at space or comma
                    for (int i = 0; i < searchTerms.Length; i++)
                    {
                        searchTerms[i] = searchTerms[i].ToLower();//sets all entered search terms to lower case, to match the database.
                    }
                    if (IncludeSynonyms.Checked)
                    {
                        DbUtilities dbUtil = new DbUtilities(newWordsFullDataSet);
                        //constructor for DbUtilities, takes in dataset as parameter. 
                        //Dataset out of scope in class variables.
                        newSearch = dbUtil.SearchWithDb(searchTerms);
                        //sets newSearch variable to return from SearchWithDb(), (terms and their synonyms)
                    }

                    var watch = System.Diagnostics.Stopwatch.StartNew();//starts a new instance of stop watch
                    if (InvertedIndex.invertedIndex.Count == 0)
                        //Builds inverted index if it yet to be built
                    {
                        index.BuildInvertedIndex(folderPath);//builds inverted Index
                    }
                    //Searches files and folders, reads contents, then fires the frequency methods.
                    if (IncludeSynonyms.Checked)
                    {
                        Search.IndexedFileMatchTermDb(newSearch);
                    }
                    else
                    {
                        Search.IndexedFileMatchTerm(searchTerms);
                    }
                    watch.Stop();//stops stop watch.
                    long time = watch.ElapsedMilliseconds;//gets the time in milliseconds
                    SearchTime.Text = time.ToString() + "ms"; //outputs time to form.
                    AverageTime.Text = Average(time).ToString() + "ms";//outputs average time to form.

                    FileToForm();//populates the listbox, number of files found and frequency textboxes
                }
            }
        }

        /*
         * sets time for SearchDir() to elapsed time.
         * Fires Average().
         * @param long time
         * @return long elapsedTime
         */
        public long ElapsedTime(long time)
        {
            elapsedTime = time;
            Average(time);
            return elapsedTime;
        }

        /*
         * Calculates the average time
         * for a search.
         * @param long aTime
         * @return long average
         */
        public long Average(long aTime)
        {
            totalTime = totalTime + aTime;
            average = totalTime / numSearch;
            return average;
        }

        /*
         * Populates form with filepaths, most common word,
         * query term frequency and files found.
         * Fires resets for collectionFreq and output,
         * so they are new objects for next search.
         * @param Boolean useDatabase.
         */
        private void FileToForm()
        {
            Dictionary<string, int> output = index.WriteToOutput();
            if (output.Count == 0)//handles no files being found.
            {
                FilePathOutput.Items.Add("No files found");
            }

            foreach (string s in output.Keys)//iterates through output, using it's getter.
            {
                FilePathOutput.Items.Add(s);//adds each string to list box.
            }
            Found.Text = (output.Count).ToString();//sets Found.Text to length of output, using it's getter.
            commonWord.Text = TermFreq.CollectionFreq();//sets commonWord.Text to return variable from CollectionFreq()
            QueryTermFreq.Text = TermFreq.QueryTermFreq(searchTerms);//sets QueryTermFreq to variable returned from QueryTermFreq()
            ICollection key = InvertedIndex.invertedIndex.Keys;//remove before submission, for debugging.
        }


        private void wordsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.wordsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.newWordsFullDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'newWordsDataSet.Words' table. You can move, or remove it, as needed.
            this.wordsTableAdapter.Fill(this.newWordsFullDataSet.Words);

        }

        /*
         * Takes the input from AddWord and AddSynonyms textboxes
         * and passes them to AddWord in DbUtilities to be added 
         * to the database.
         */
        private void AddEntryBut_Click(object sender, EventArgs e)
        {
            DbUtilities dbUtil = new DbUtilities(newWordsFullDataSet);
            //constructor for DbUtilities, takes in dataset as parameter. 
            //Dataset out of scope in class variables.
            if (AddWord.Text == "")//error checking for blank textbox
            {
                MessageBox.Show("Please enter a word, and try again");
            }
            if (AddWord.Text != "")//fires is AddWord textbox is not blank.
            {
                String word = AddWord.Text;//setting variable to be passed
                String syn = AddSynonym.Text;//setting variable to be passed
                dbUtil.AddWord(word, syn);//calls method in DbUtilities
                //uses local word and syn, and passes the database, so it can be accessed.
            }
            //resets textboxes to blank.
            AddWord.Text = "";
            AddSynonym.Text = "";
        }

        /*
         * Takes the input from DeleteWord textbox
         * and passes it to the method DeleteWord
         * in DbUtilities to remove it from the 
         * database.
         */
        private void DeleteWordBut_Click(object sender, EventArgs e)
        {
            DbUtilities dbUtil = new DbUtilities(newWordsFullDataSet);
            //constructor for DbUtilities, takes in dataset as parameter. 
            //Dataset out of scope in class variables.
            if (DeleteWord.Text == "")//checks to see if the textbox is blank.
            {
                MessageBox.Show("Please enter a word and try again");
            }
            if (DeleteWord.Text != "")//fires if textbox is not blank.
            {
                String delWord = DeleteWord.Text;//sets variable to be passed.
                dbUtil.DeleteWord(delWord);//calls DeleteWord method in DbUtilitites.
                //Passes local variable delWord and the database, so it can be accessed.
                DeleteWord.Text = "";//sets textbox back to blank.
            }
        }

        /*
         * Takes the input from UpdateWord and UpdateSynonym textboxes
         * and passes them to the method UpdateWord in DbUtilities
         * class, so that the new synonym can be appended to the end
         * of the synonym list.
         */
        private void UpdateEntryBut_Click(object sender, EventArgs e)
        {
            DbUtilities dbUtil = new DbUtilities(newWordsFullDataSet);
            //constructor for DbUtilities, takes in dataset as parameter. 
            //Dataset out of scope in class variables.
            if (UpdateWord.Text == "")//checks to see if UpdateWord textbox is blank
            {
                MessageBox.Show("Please enter a word and try again");
            }
            if (UpdateWord.Text != "")//fires if textbox is not blank.
            {
                String word = UpdateWord.Text;//sets local variable to be passed.
                String syn = UpdateSynonym.Text;//sets local variable to be passed
                dbUtil.UpdateWord(word, syn);//calls UpdateWord method in DbUtilities.
                                             //Passes local variables word and syn as parameters. Also passes the database so it can be accessed.
                UpdateSynonym.Text = "";//sets textbox to blank
                UpdateWord.Text = "";//sets textbox to blank.
            }
        }

        /*
         * Takes the input from QueryWord textbox, and passes it to QueryWord
         * in DbUtilities, which queries it, then returns a string of
         * the synonyms, to be displayed in QuerySynonym textbox.
         */
        private void QueryEntryBut_Click(object sender, EventArgs e)
        {
            DbUtilities dbUtil = new DbUtilities(newWordsFullDataSet);
            //constructor for DbUtilities, takes in dataset as parameter. 
            //Dataset out of scope in class variables.
            if (QueryWord.Text == "")//error handling for no value entered into textbox.
            {
                MessageBox.Show("Please enter a word and try again");
            }
            if (QueryWord.Text != "")//fires if textbox is not blank.
            {
                string word = QueryWord.Text;//sets local variable for passing.
                string aStr = dbUtil.Query(word);//Calls Query in DbUtilities.
                                                 //Sets local variable aStr to the return str from Query.
                QuerySynonym.Text = aStr;//sets the text in the text box to aStr.
            }
        }

        /*
         * Allows file to be opened by double clicking on them. 
         */
        private void FilePathOutput_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int index = FilePathOutput.IndexFromPoint(e.Location);
                //sets the index for folder mouse has double clicked.
                if (index != System.Windows.Forms.ListBox.NoMatches)//fires if index is not -1
                {
                    System.Diagnostics.Process.Start(FilePathOutput.SelectedItem.ToString());
                    //opens the file that was double clicked on.
                }
            }
            catch(Exception err)
            {
                MessageBox.Show("Error: File cannot be opened." + err);
            }

        }

        /*
         * Rebuilds inverted index in a seperate thread 
         * when refresh button pressed
         */
        private void RefreshIndex_Click(object sender, EventArgs e)
        {         
            rebuild = true;// triggers message box when search pressed.
            if (folderPath == null)//checks a folder path has been selected
            {
                MessageBox.Show("Please select a folder and try again.");
            }
            else
            {//Declares a new thread method
                Thread T1 = new Thread(new ThreadStart(() =>
                 {
                     index.ResetInvertedIndex();//clears index
                     index.BuildInvertedIndex(folderPath);//builds index
                     rebuild = false;//sets boolean for thread running to false
                 }
                 ));
                T1.Start();//starts thread
            }
        }

    }
}

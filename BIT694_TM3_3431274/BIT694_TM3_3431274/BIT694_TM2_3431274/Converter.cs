using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT694_TM2_3431274
{
    /*
     *Obtained from: 
     *Open Polytechnic. (2017). 
     * Performance and optimization. 
     * Retrieved September 29, 2017, 
     * from BIT694 Developing Applications using c#, 
     * Open Polytechnic: 
     * https://openpolytechnic.iqualify.com/course/-KkhzLXn7OHayauSqVt6/#/page/p68
     * 
     * Modified to make paths and ids static and namespace changed.
     * Comments: Penny Williamson
     */
    class Converter
    {
        private int counter; //counter to hold current fileId 

        //Static to avoid garbage collection.
        static private Hashtable paths;//

        static private ArrayList ids;

        /*
         * Constructor
         */
        public Converter()
        {
            counter = 0;//sets counter for fileId to 0

            paths = new Hashtable();//sets new HashTable

            ids = new ArrayList();//sets new ArrayList

        } 

        /*
         * Returns the fileId for a string path
         * @param String path
         * @return int fileId
         */ 
        public int GetID(String path) 
        {

            return ((int)paths[path]);

        }

        /*
         * Returns the file path associated with fileId
         * @param int id
         * @return String filePath
         */
        public string GetPath(int id) 
        {

            return ((string)ids[id]);

        }

        /*
         * Assigns fileId to filePath.
         * @param string path
         * @return int fileId
         */
        public int AssignId(string path) 
        {

            int id = counter;//sets id to current counter value

            counter++;//increases counter by 1

            paths[path] = id;//associates path with id

            ids.Add(path);//associates id with file path

            return (id);//returns the fileId

        } 
    }
}

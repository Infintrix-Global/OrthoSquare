using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrthoSquare.Common1
{
    
    public class A_File_Upload
    {
        public string Fname { get; set; }
       
        public string Fext { get; set; }
    }


    public class File_Upload_Response
    {
        public string path { get; set; }

        public string status { get; set; }

    }
}
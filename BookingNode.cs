using System;
using System.Collections.Generic;
using System.Text;

namespace Labb_7
{
    // En klass som representerar en nod i ett binärt sökträd för tidsbokningar
    public class BookingNode
    {

        public DateTime Time { get; set; }
        public string PatientName { get; set; }

        public BookingNode Left { get; set; }
        public BookingNode Right { get; set; }

        
        public BookingNode(DateTime time, string patientName)
        {
            Time = time;
            PatientName = patientName;
        }

    }
}

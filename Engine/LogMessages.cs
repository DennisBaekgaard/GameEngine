using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Engine
{
    public class LogMessages
    {


        private List<Tuple<string, Color>> message = new List<Tuple<string, Color>>();

        public List<Tuple<string, Color>> Message
        {
            get { return message; }
        }

        public LogMessages() { }

        public void Add(string msg, Color color)
        {
            message.Add(new Tuple<string, Color>(msg, color));
        }

        public void Clear()
        {
            message.Clear();
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA_DataWarehouse.Helper {
    /// <summary>
    /// Just a simple helper to shorten logging actions
    /// </summary>
    class Logger {
        /// <summary>
        /// The listbox to Log into
        /// </summary>
        private ListBox listBox;

        /// <summary>
        /// Simple constructor
        /// </summary>
        /// <param name="listBox">The ListBox to Log into</param>
        public Logger(ListBox listBox) {
            this.listBox = listBox;

            this.Log("logging initialized");
        }

        /// <summary>
        /// Add a message to the logger ListBox.
        /// </summary>
        /// <param name="message">The message to display</param>
        public void Log(String message) {

            DateTime timestamp = DateTime.Now;
            message = timestamp.ToString("dd.MM.yyyy HH:mm:ss : ") + message;

            //Prevent overflow
            if (this.listBox.Items.Count > 500) {
                this.listBox.Items.RemoveAt(0);
            }
            this.listBox.Items.Add(message);
        }
    }
}

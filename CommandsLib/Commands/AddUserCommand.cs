using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandsLib
{
    public class AddUserCommand : System.Windows.Input.ICommand
    {
        public string Category { get; set; }
        public int UserId { get; set; }
        //private TCP db { get; set; }

        //public AddUserCommand(Database db)
        //{
        //    this.db = db;
        //}

        event EventHandler System.Windows.Input.ICommand.CanExecuteChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public void Execute(object obj = null)
        {
            /////////////////////////////////////////////////////////////////////////////////////////
        }

        public bool CanExecute(object obj)
        {
            return true;
        }

    }

}

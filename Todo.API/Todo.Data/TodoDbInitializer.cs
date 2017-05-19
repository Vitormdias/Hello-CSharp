using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Data
{
    public class TodoDbInitializer
    {
        private static TodoContext context;

        public static void Initialize (IServiceProvider serviceProvider)
        {
            context = (TodoContext)serviceProvider.GetService(typeof(TodoContext));
        }
    }
}

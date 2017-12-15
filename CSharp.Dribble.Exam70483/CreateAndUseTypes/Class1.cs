using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Dribble.Exam70483.CreateAndUseTypes
{
    interface ILion
    {
        void Run();
    }
    interface IMan
    {
        void Run();
    }

    public class Animal : ILion, IMan
    {
        // Error CS0106  The modifier 'public' is not valid for this item!

        //public void IMan.Run()
        //{
        //}

        void IMan.Run()
        {
        }
        void ILion.Run()
        {
        }
    }
}

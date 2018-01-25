using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Dribble.Exam70483.Exceptions
{
    public class TryCatchFinally
    {
        public void CanTryCatchFinallyInAllBlocks()
        {
            try
            {
                try
                {

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                }

            }
            catch (Exception)
            {
                try
                {

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                }
            }
            finally
            {
                try
                {

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                }
            }
        }
    }
}

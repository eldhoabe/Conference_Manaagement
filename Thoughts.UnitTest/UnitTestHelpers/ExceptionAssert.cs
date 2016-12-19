using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thoughts.UnitTest.UnitTestHelpers
{
    public static class ExceptionAssert
    {
        /// <summary>
        /// Exception Assert
        /// </summary>
        /// <typeparam name="T">The type of exception</typeparam>
        /// <param name="action">The action method</param>
        /// <returns>Exception</returns>
        public static T Throws<T>(Action action) where T : Exception
        {
            try
            {
                action();
            }
            catch (T ex)
            {
                return ex;
            }

            Assert.Fail("Expected exception of type {0}.", typeof(T));

            return null;
        }
    }
}

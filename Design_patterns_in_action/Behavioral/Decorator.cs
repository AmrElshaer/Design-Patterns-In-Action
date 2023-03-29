using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns_in_action.Behavioral
{
    internal class Decorator
    {
        void Run()
        {
            var fileStreem = new FileStreem();
            var cryptoStreem = new CryptoStreem(fileStreem);
            var bufferStreem = new BufferStreem(cryptoStreem);
            bufferStreem.Write("hello world");
        }

        #region Framework code you can't change but you can decorate it (OCP)
        interface IStreem
        {
            void Write(string message);
        }
        class FileStreem : IStreem
        {
            public void Write(string message)
            {
                Console.WriteLine($"this message get from file {message}");
            }
        }
        class NetworkStreem : IStreem
        {
            public void Write(string message)
            {
                Console.WriteLine($"this message get from Network {message}");
            }
        }
        #endregion
        #region you need to consume existed streem and add new functionality
        /// <summary>
        /// The idea is that you can create an object that wraps an another object (of the same type) in
        /// order to provide new functionalities and the resulting object can be
        /// wrapped again creating a chain (chain is like chain of responsibilty but the chain in it is one or more subscribe for this request but in decorator all is subscribe)of objects that together provide a combination of functionalities.
        /// </summary>
        class CryptoStreem : IStreem
        {
            private readonly IStreem streem;

            public CryptoStreem(IStreem streem)
            {
                this.streem = streem;
            }

            public void Write(string message)
            {
                Console.WriteLine("add crypto for the message");
                streem.Write(message);

            }
        }
        class BufferStreem : IStreem
        {
            private readonly IStreem streem;
            public BufferStreem(IStreem streem)
            {
                this.streem = streem;
            }
            public void Write(string message)
            {
                Console.WriteLine("buffer message to the memory");
                streem.Write(message);
            }
        }
        #endregion
    }
}

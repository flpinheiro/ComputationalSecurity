using System;
using System.IO;
using System.Numerics;
using System.Text;
using UnB.Security.Services;
using Xunit;

namespace UnB.Security.Test
{
    public class RSATest
    {
        private readonly Domain.RSA  rsa;
        public RSATest()
        {
            rsa = Generator.GenRSA();
        }

        [Theory]
        [InlineData("Bela noite de verão")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi facilisis dui a magna gravida ultrices. Nam molestie sodales quam, ut accumsan mauris maximus in. Integer ut sodales tellus. Pellentesque rhoncus eget orci at condimentum. Sed tincidunt, lectus vel sagittis fermentum, neque massa rutrum purus, bibendum tristique erat tortor quis lorem. Vivamus sit amet dolor ac tellus ultrices ornare eu ut metus. Proin gravida tincidunt consectetur. Vestibulum tristique mi id posuere commodo. Sed pulvinar rutrum sagittis. Donec maximus elementum ex, quis scelerisque odio facilisis eu. Curabitur vestibulum aliquet mattis. Curabitur et enim id dolor rhoncus sodales at ac odio.")]
        public void RsaTrue(string message)
        {
            var hashRSA = Signer.Sign(rsa.PrivateKey, message);
            var result = Checker.Vrfy(rsa.PublicKey, hashRSA);
            Assert.True(result);
        }

        [Theory]
        [InlineData("bela noite de verão")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi facilisis dui a magna gravida ultrices. Nam molestie sodales quam, ut accumsan mauris maximus in. Integer ut sodales tellus. Pellentesque rhoncus eget orci at condimentum. Sed tincidunt, lectus vel sagittis fermentum, neque massa rutrum purus, bibendum tristique erat tortor quis lorem. Vivamus sit amet dolor ac tellus ultrices ornare eu ut metus. Proin gravida tincidunt consectetur. Vestibulum tristique mi id posuere commodo. Sed pulvinar rutrum sagittis. Donec maximus elementum ex, quis scelerisque odio facilisis eu. Curabitur vestibulum aliquet mattis. Curabitur et enim id dolor rhoncus sodales at ac odio.")]
        public void RsaFalse(string message) 
        {
            var hashRSA = Signer.Sign(rsa.PrivateKey, message);
            message = message.Insert(message.Length, "alteração no final");
            hashRSA = new Domain.RSAMessage(message, hashRSA.Sigma);
            var result = Checker.Vrfy(rsa.PublicKey, hashRSA);
            Assert.False(result);
        }

        [Fact]
        public void RsaTextTrue()
        {
            var path = Environment.CurrentDirectory;
            path = Directory.GetParent(path).Parent.Parent.FullName;
            path = Path.Combine(path, "LoremIpsum.txt");

            var sr = new StreamReader(path);

            Signer.SignFile(rsa.PrivateKey,sr);

            path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, "upload.txt");

            sr = new StreamReader(path);

            var result = Checker.VrfyFile(rsa.PublicKey,sr);

            Assert.True(result);

        }

    }
}

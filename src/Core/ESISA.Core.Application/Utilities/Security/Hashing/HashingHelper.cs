using ESISA.Core.Application.Dtos.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static HashResultDto ComputeHashByKeyValue(string keyValue)
        {
            using (var securityAlgorithm = new HMACSHA256())
            {
                var salt = securityAlgorithm.Key;
                var hash = securityAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(keyValue));

                return new(hash, salt);
            }
        }

        public static bool VerifyHashes(string value, byte[] originalHash, byte[] computedSalt)
        {
            using (var securityAlgorith = new HMACSHA256(computedSalt))
            {
                byte[] computedHash = securityAlgorith.ComputeHash(Encoding.UTF8.GetBytes(value));

                return CompareHashes(originalHash, computedHash);
            }
        }

        private static bool CompareHashes(byte[] originalHash, byte[] computedHash)
        {
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != originalHash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}

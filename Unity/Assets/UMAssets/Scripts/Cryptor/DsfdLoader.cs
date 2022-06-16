using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System;

namespace Cryptor
{
    public class DsfdLoader
    {
        public interface ILoadRequest
        {
            bool IsDone { get; } // Slot: 0
            bool IsSuccess { get; } // Slot: 1
            byte[] Result { get; } // Slot: 2
            string FilePath { get; } // Slot: 3
        }

        public class LoadRequest : ILoadRequest
        {
            private object lockObject; // 0x8
            
            public bool IsDone { get; set; } // IsDone 0xC
            public bool IsSuccess { get; set; } // IsSuccess 0xD
            public byte[] Result { get; set; } // Result // 0x10
            public string FilePath { get; set; } // FilePath // 0x14

            // // RVA: 0x2BAFBC4 Offset: 0x2BAFBC4 VA: 0x2BAFBC4
            public void FinishRequest(bool succeed, byte[] result)
            { 
                IsDone = true;
                IsSuccess = succeed;
                Result = result;
            }

            public LoadRequest(string path)
            {
                lockObject = new object();
                IsDone = false;
                Result = null;
                FilePath = path;
            }
        }

        private class Key
        {
            public byte[] key = new byte[16];
        }

        private class KeyGenerator
        {
            static private bool GetSeedFromString(Key key, string seed)
            {
                if(seed.StartsWith("0x"))
                {
                    seed.Replace("0x","");
                }
                if(0x20 != seed.Length)
                {
                    Debug.LogError("Seed size don't match");
                    return false;
                }
                for(int i = 0; i < 16; i++)
                {
                    key.key[i] = (byte)int.Parse(seed.Substring(i*2, 2),System.Globalization.NumberStyles.HexNumber);
                }
                return true;
            }

            static public bool Gen(Key key, string seed1, string seed2, string seed3)
            {
                Key k1 = new Key();
                Key k2 = new Key();
                Key k3 = new Key();
                if(!GetSeedFromString(k1, seed1))
                    return false;
                if(!GetSeedFromString(k2, seed2))
                    return false;
                if(!GetSeedFromString(k3, seed3))
                    return false;
                //ldmia int to byte[4] order?
                byte[] h = new byte[0x30] { 
                    0xd3, 0x1f, 0x5d, 0xdd,//0xdd5d1fd3, 
                    0x61, 0x4b, 0xeb, 0x82,//0x82eb4b61, 
                    0x8f, 0x86, 0x37, 0x81,//0x8137868f, 
                    0xf0, 0xb2, 0x52, 0xd4,//0xd452b2f0, 
                    0x52, 0x3f, 0x1c, 0x1e,//0x1e1c3f52, 
                    0xcc, 0x05, 0x22, 0x22,//0x222205cc, 
                    0x08, 0x78, 0xef, 0xe5,//0xe5ef7808, 
                    0xeb, 0x25, 0xa0, 0xc4,//0xc4a025eb, 
                    0x82, 0x2c, 0xc1, 0x8c,//0x8cc12c82, 
                    0x02, 0xe8, 0x12, 0x81,//0x8112e802, 
                    0x8d, 0xaa, 0x51, 0xa8,//0xa851aa8d, 
                    0xf2, 0x79, 0xc6, 0x1d//0x1dc679f2 
                };

                byte[] resTotal = new byte[0x30];

                IncrementalHash im = IncrementalHash.CreateHash(HashAlgorithmName.MD5);
                im.AppendData(k1.key, 0, 0x10);
                im.AppendData(h, 0, 0x10);
                byte[] res1 = im.GetHashAndReset();
                System.Buffer.BlockCopy(res1, 0, resTotal, 0, 0x10);

                im.AppendData(k2.key, 0, 0x10);
                im.AppendData(h, 0x10, 0x10);
                res1 = im.GetHashAndReset();
                System.Buffer.BlockCopy(res1, 0, resTotal, 0x10, 0x10);

                im.AppendData(k3.key, 0, 0x10);
                im.AppendData(h, 0x20, 0x10);
                res1 = im.GetHashAndReset();
                System.Buffer.BlockCopy(res1, 0, resTotal, 0x20, 0x10);

                im.AppendData(resTotal, 0, 0x30);
                key.key = im.GetHashAndReset();
                return true;
            }
        }

        // https://github.com/MersenneTwister-Lab/XSadd/blob/master/xsadd.c
        private class XSadd
        {
            uint[] state;

            const int LOOP = 8;


            /**
            * This function initializes the internal state array with a 32-bit
            * unsigned integer seed.
            * @param[out] xsadd xsadd state vector.
            * @param[in] seed a 32-bit unsigned integer used as a seed.
            */
            public void Init(uint seed)
            {
                state = new uint[4];
                state[0] = seed;
                state[1] = 0;
                state[2] = 0;
                state[3] = 0;
                for (int i = 1; i < LOOP; i++) {
                    state[i & 3] ^= (uint)(i + 1812433253
                        * (state[(i - 1) & 3]
                        ^ (state[(i - 1) & 3] >> 30)));
                }
                PeriodCertification();
                for (int i = 0; i < LOOP; i++) {
                    NextState();
                }
            }

            void PeriodCertification()
            {
                if (state[0] == 0 &&
                    state[1] == 0 &&
                    state[2] == 0 &&
                    state[3] == 0) {
                    state[0] = 'X';
                    state[1] = 'S';
                    state[2] = 'A';
                    state[3] = 'D';
                }
            }

            /**
            * This function changes internal state of xsadd.
            * Users should not call this function directly.
            * @param[in,out] xsadd xsadd internal state
            */
            void NextState()
            {
                const int sh1 = 15;
                const int sh2 = 18;
                const int sh3 = 11;
                uint t;
                t = state[0];
                t ^= t << sh1;
                t ^= t >> sh2;
                t ^= state[3] << sh3;
                state[0] = state[1];
                state[1] = state[2];
                state[2] = state[3];
                state[3] = t;
            }

            /**
            * This function outputs 32-bit unsigned integer from internal state.
            * @param[in,out] xsadd xsadd internal state
            * @return 32-bit unsigned integer r (0 <= r < 2^32)
            */
            public uint UInt32()
            {
                NextState();
                return state[3] + state[2];
            }
        }

        private class DeRandomXSadd
        {
            XSadd xsadd;
            public DeRandomXSadd()
            {
                xsadd = new XSadd();
            }

            public void SetSeed(uint seed)
            {
                xsadd.Init(seed);
            }

            public void GetRandBytes(byte[] outData, int size)
            {
                int numInt = size / 4;
                int idx = 0;
                while(numInt > 0)
                {
                    uint rand = xsadd.UInt32();
                    outData[idx++] = (byte)rand;
                    outData[idx++] = (byte)(rand >> 8);
                    outData[idx++] = (byte)(rand >> 16);
                    outData[idx++] = (byte)(rand >> 24);
                    numInt--;
                }
                if((size & 0x3) != 0)
                {
                    uint rand = xsadd.UInt32();
                    for(int i = 0; i < (size & 0x3); i++)
                    {
                        outData[idx++] = (byte)(rand >> (i*8));
                    }
                }
            }
        }

        // https://docs.huihoo.com/doxygen/cryptlib/3.4.1/aes_8h_source.html
        // https://docs.huihoo.com/doxygen/cryptlib/3.4.1/aestab_8c_source.html
        // https://docs.huihoo.com/doxygen/cryptlib/3.4.1/aescrypt_8c_source.html
        // https://docs.huihoo.com/doxygen/cryptlib/3.4.1/aeskey_8c_source.html

        private class AesEncryptContext
        {
            public uint[] ks = new uint[60];
            public byte[] b = new byte[4]; // union uint l;
        }

        private class Aes
        {
            static uint[] t_rc;
            static uint[][] t_fn;
            static uint[][] t_fl;
            static uint[][] t_in;
            static uint[][] t_il;
            public static int AES_BLOCK_SIZE = 16;
            static int RC_LENGTH = 5 * (AES_BLOCK_SIZE / 4 - 2);
            static int N_COLS = 4;
            static int WPOLY = 0x011b;


            // FIXED_TABLES DO_TABLES
            static Aes()
            {

                /*byte[] mm_data = new byte[] {
                    0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07,
                    0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f,
                    0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17,
                    0x18, 0x19, 0x1a, 0x1b, 0x1c, 0x1d, 0x1e, 0x1f,
                    0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27,
                    0x28, 0x29, 0x2a, 0x2b, 0x2c, 0x2d, 0x2e, 0x2f,
                    0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37,
                    0x38, 0x39, 0x3a, 0x3b, 0x3c, 0x3d, 0x3e, 0x3f,
                    0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47,
                    0x48, 0x49, 0x4a, 0x4b, 0x4c, 0x4d, 0x4e, 0x4f,
                    0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57,
                    0x58, 0x59, 0x5a, 0x5b, 0x5c, 0x5d, 0x5e, 0x5f,
                    0x60, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67,
                    0x68, 0x69, 0x6a, 0x6b, 0x6c, 0x6d, 0x6e, 0x6f,
                    0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77,
                    0x78, 0x79, 0x7a, 0x7b, 0x7c, 0x7d, 0x7e, 0x7f,
                    0x80, 0x81, 0x82, 0x83, 0x84, 0x85, 0x86, 0x87,
                    0x88, 0x89, 0x8a, 0x8b, 0x8c, 0x8d, 0x8e, 0x8f,
                    0x90, 0x91, 0x92, 0x93, 0x94, 0x95, 0x96, 0x97,
                    0x98, 0x99, 0x9a, 0x9b, 0x9c, 0x9d, 0x9e, 0x9f,
                    0xa0, 0xa1, 0xa2, 0xa3, 0xa4, 0xa5, 0xa6, 0xa7,
                    0xa8, 0xa9, 0xaa, 0xab, 0xac, 0xad, 0xae, 0xaf,
                    0xb0, 0xb1, 0xb2, 0xb3, 0xb4, 0xb5, 0xb6, 0xb7,
                    0xb8, 0xb9, 0xba, 0xbb, 0xbc, 0xbd, 0xbe, 0xbf,
                    0xc0, 0xc1, 0xc2, 0xc3, 0xc4, 0xc5, 0xc6, 0xc7,
                    0xc8, 0xc9, 0xca, 0xcb, 0xcc, 0xcd, 0xce, 0xcf,
                    0xd0, 0xd1, 0xd2, 0xd3, 0xd4, 0xd5, 0xd6, 0xd7,
                    0xd8, 0xd9, 0xda, 0xdb, 0xdc, 0xdd, 0xde, 0xdf,
                    0xe0, 0xe1, 0xe2, 0xe3, 0xe4, 0xe5, 0xe6, 0xe7,
                    0xe8, 0xe9, 0xea, 0xeb, 0xec, 0xed, 0xee, 0xef,
                    0xf0, 0xf1, 0xf2, 0xf3, 0xf4, 0xf5, 0xf6, 0xf7,
                    0xf8, 0xf9, 0xfa, 0xfb, 0xfc, 0xfd, 0xfe, 0xff
                };*/

                // DO_TABLES & FIXED_TABLES
                t_rc = rc_data(w0);

                // FT4_SET
                t_fn = new uint[4][] { sb_data(u0), sb_data(u1), sb_data(u2), sb_data(u3) };

                // FL4_SET
                t_fl = new uint[4][] { sb_data(w0), sb_data(w1), sb_data(w2), sb_data(w3) };

                // IT4_SET
                t_in = new uint[4][] { isb_data(v0), isb_data(v1), isb_data(v2), isb_data(v3) };

                // IL4_SET
                t_il = new uint[4][] { isb_data(w0), isb_data(w1), isb_data(w2), isb_data(w3) };
            }

            public static uint[] rc_data(Func<byte, uint> w)
            {
                byte[] rc_data_ = new byte[] {
                    0x01, 0x02, 0x04, 0x08, 0x10,0x20, 0x40, 0x80,
                    0x1b, 0x36 
                };
                uint[] result = new uint[rc_data_.Length];
                for(int i = 0; i < rc_data_.Length; i++)
                {
                    result[i] = w(rc_data_[i]);
                }
                return result;
            }

            public static uint[] sb_data(Func<byte, uint> w)
            {
                byte[] sb_data_ = new byte[] {
                    0x63, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5,
                    0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76,
                    0xca, 0x82, 0xc9, 0x7d, 0xfa, 0x59, 0x47, 0xf0,
                    0xad, 0xd4, 0xa2, 0xaf, 0x9c, 0xa4, 0x72, 0xc0,
                    0xb7, 0xfd, 0x93, 0x26, 0x36, 0x3f, 0xf7, 0xcc,
                    0x34, 0xa5, 0xe5, 0xf1, 0x71, 0xd8, 0x31, 0x15,
                    0x04, 0xc7, 0x23, 0xc3, 0x18, 0x96, 0x05, 0x9a,
                    0x07, 0x12, 0x80, 0xe2, 0xeb, 0x27, 0xb2, 0x75,
                    0x09, 0x83, 0x2c, 0x1a, 0x1b, 0x6e, 0x5a, 0xa0,
                    0x52, 0x3b, 0xd6, 0xb3, 0x29, 0xe3, 0x2f, 0x84,
                    0x53, 0xd1, 0x00, 0xed, 0x20, 0xfc, 0xb1, 0x5b,
                    0x6a, 0xcb, 0xbe, 0x39, 0x4a, 0x4c, 0x58, 0xcf,
                    0xd0, 0xef, 0xaa, 0xfb, 0x43, 0x4d, 0x33, 0x85,
                    0x45, 0xf9, 0x02, 0x7f, 0x50, 0x3c, 0x9f, 0xa8,
                    0x51, 0xa3, 0x40, 0x8f, 0x92, 0x9d, 0x38, 0xf5,
                    0xbc, 0xb6, 0xda, 0x21, 0x10, 0xff, 0xf3, 0xd2,
                    0xcd, 0x0c, 0x13, 0xec, 0x5f, 0x97, 0x44, 0x17,
                    0xc4, 0xa7, 0x7e, 0x3d, 0x64, 0x5d, 0x19, 0x73,
                    0x60, 0x81, 0x4f, 0xdc, 0x22, 0x2a, 0x90, 0x88,
                    0x46, 0xee, 0xb8, 0x14, 0xde, 0x5e, 0x0b, 0xdb,
                    0xe0, 0x32, 0x3a, 0x0a, 0x49, 0x06, 0x24, 0x5c,
                    0xc2, 0xd3, 0xac, 0x62, 0x91, 0x95, 0xe4, 0x79,
                    0xe7, 0xc8, 0x37, 0x6d, 0x8d, 0xd5, 0x4e, 0xa9,
                    0x6c, 0x56, 0xf4, 0xea, 0x65, 0x7a, 0xae, 0x08,
                    0xba, 0x78, 0x25, 0x2e, 0x1c, 0xa6, 0xb4, 0xc6,
                    0xe8, 0xdd, 0x74, 0x1f, 0x4b, 0xbd, 0x8b, 0x8a,
                    0x70, 0x3e, 0xb5, 0x66, 0x48, 0x03, 0xf6, 0x0e,
                    0x61, 0x35, 0x57, 0xb9, 0x86, 0xc1, 0x1d, 0x9e,
                    0xe1, 0xf8, 0x98, 0x11, 0x69, 0xd9, 0x8e, 0x94,
                    0x9b, 0x1e, 0x87, 0xe9, 0xce, 0x55, 0x28, 0xdf,
                    0x8c, 0xa1, 0x89, 0x0d, 0xbf, 0xe6, 0x42, 0x68,
                    0x41, 0x99, 0x2d, 0x0f, 0xb0, 0x54, 0xbb, 0x16
                };

                uint[] result = new uint[sb_data_.Length];
                for(int i = 0; i < sb_data_.Length; i++)
                {
                    result[i] = w(sb_data_[i]);
                }
                return result;

            }

            public static uint[] isb_data(Func<byte, uint> w)
            {
                byte[] isb_data_ = new byte[] {
                    0x52, 0x09, 0x6a, 0xd5, 0x30, 0x36, 0xa5, 0x38,
                    0xbf, 0x40, 0xa3, 0x9e, 0x81, 0xf3, 0xd7, 0xfb,
                    0x7c, 0xe3, 0x39, 0x82, 0x9b, 0x2f, 0xff, 0x87,
                    0x34, 0x8e, 0x43, 0x44, 0xc4, 0xde, 0xe9, 0xcb,
                    0x54, 0x7b, 0x94, 0x32, 0xa6, 0xc2, 0x23, 0x3d,
                    0xee, 0x4c, 0x95, 0x0b, 0x42, 0xfa, 0xc3, 0x4e,
                    0x08, 0x2e, 0xa1, 0x66, 0x28, 0xd9, 0x24, 0xb2,
                    0x76, 0x5b, 0xa2, 0x49, 0x6d, 0x8b, 0xd1, 0x25,
                    0x72, 0xf8, 0xf6, 0x64, 0x86, 0x68, 0x98, 0x16,
                    0xd4, 0xa4, 0x5c, 0xcc, 0x5d, 0x65, 0xb6, 0x92,
                    0x6c, 0x70, 0x48, 0x50, 0xfd, 0xed, 0xb9, 0xda,
                    0x5e, 0x15, 0x46, 0x57, 0xa7, 0x8d, 0x9d, 0x84,
                    0x90, 0xd8, 0xab, 0x00, 0x8c, 0xbc, 0xd3, 0x0a,
                    0xf7, 0xe4, 0x58, 0x05, 0xb8, 0xb3, 0x45, 0x06,
                    0xd0, 0x2c, 0x1e, 0x8f, 0xca, 0x3f, 0x0f, 0x02,
                    0xc1, 0xaf, 0xbd, 0x03, 0x01, 0x13, 0x8a, 0x6b,
                    0x3a, 0x91, 0x11, 0x41, 0x4f, 0x67, 0xdc, 0xea,
                    0x97, 0xf2, 0xcf, 0xce, 0xf0, 0xb4, 0xe6, 0x73,
                    0x96, 0xac, 0x74, 0x22, 0xe7, 0xad, 0x35, 0x85,
                    0xe2, 0xf9, 0x37, 0xe8, 0x1c, 0x75, 0xdf, 0x6e,
                    0x47, 0xf1, 0x1a, 0x71, 0x1d, 0x29, 0xc5, 0x89,
                    0x6f, 0xb7, 0x62, 0x0e, 0xaa, 0x18, 0xbe, 0x1b,
                    0xfc, 0x56, 0x3e, 0x4b, 0xc6, 0xd2, 0x79, 0x20,
                    0x9a, 0xdb, 0xc0, 0xfe, 0x78, 0xcd, 0x5a, 0xf4,
                    0x1f, 0xdd, 0xa8, 0x33, 0x88, 0x07, 0xc7, 0x31,
                    0xb1, 0x12, 0x10, 0x59, 0x27, 0x80, 0xec, 0x5f,
                    0x60, 0x51, 0x7f, 0xa9, 0x19, 0xb5, 0x4a, 0x0d,
                    0x2d, 0xe5, 0x7a, 0x9f, 0x93, 0xc9, 0x9c, 0xef,
                    0xa0, 0xe0, 0x3b, 0x4d, 0xae, 0x2a, 0xf5, 0xb0,
                    0xc8, 0xeb, 0xbb, 0x3c, 0x83, 0x53, 0x99, 0x61,
                    0x17, 0x2b, 0x04, 0x7e, 0xba, 0x77, 0xd6, 0x26,
                    0xe1, 0x69, 0x14, 0x63, 0x55, 0x21, 0x0c, 0x7d
                };

                uint[] result = new uint[isb_data_.Length];
                for(int i = 0; i < isb_data_.Length; i++)
                {
                    result[i] = w(isb_data_[i]);
                }
                return result;
            }

            public static int aes_encrypt_key(byte[] key, int key_len, AesEncryptContext cx)
            {
                switch(key_len)
                {
                    case 16: case 128: return aes_encrypt_key_128(key, cx);
                    //case 24: case 192: return aes_encrypt_key_192(key, cx);
                    //case 32: case 256: return aes_encrypt_key_256(key, cx);
                    default: return 1;
                }
            }

            public static uint w0(byte p)
            {
                return bytes2word(p, 0, 0, 0);
            }
            public static uint w1(byte p)
            {
                return bytes2word(0, p, 0, 0);
            }
            public static uint w2(byte p)
            {
                return bytes2word(0, 0, p, 0);
            }
            public static uint w3(byte p)
            {
                return bytes2word(0, 0, 0, p);
            }

            public static uint u0(byte p)
            {
                return bytes2word(f2(p), p, p, f3(p));
            }
            public static uint u1(byte p)
            {
                return bytes2word(f3(p), f2(p), p, p);
            }
            public static uint u2(byte p)
            {
                return bytes2word(p, f3(p), f2(p), p);
            }
            public static uint u3(byte p)
            {
                return bytes2word(p, p, f3(p), f2(p));
            }

            public static uint v0(byte p)
            {
                return bytes2word(fe(p), f9(p), fd(p), fb(p));
            }
            public static uint v1(byte p)
            {
                return bytes2word(fb(p), fe(p), f9(p), fd(p));
            }
            public static uint v2(byte p)
            {
                return bytes2word(fd(p), fb(p), fe(p), f9(p));
            }
            public static uint v3(byte p)
            {
                return bytes2word(f9(p), fd(p), fb(p), fe(p));
            }

            public static byte f2(byte x)
            {
                return (byte)((x<<1) ^ (((x>>7) & 1) * WPOLY));
            }
            public static byte f4(byte x)
            {
                return (byte)((x<<2) ^ (((x>>6) & 1) * WPOLY) ^ (((x>>6) & 2) * WPOLY));
            }
            public static byte f8(byte x)
            {
                return (byte)((x<<3) ^ (((x>>5) & 1) * WPOLY) ^ (((x>>5) & 2) * WPOLY) ^ (((x>>5) & 4) * WPOLY));
            }
            public static byte f3(byte x)
            {
                return (byte)(f2(x) ^ x);
            }
            public static byte f9(byte x)
            {
                return (byte)(f8(x) ^ x);
            }
            public static byte fb(byte x)
            {
                return (byte)(f8(x) ^ f2(x) ^ x);
            }
            public static byte fd(byte x)
            {
                return (byte)(f8(x) ^ f4(x) ^ x);
            }
            public static byte fe(byte x)
            {
                return (byte)(f8(x) ^ f4(x) ^ f2(x));
            }

            public static uint vf1(uint x, uint r, uint c)
            {
                return x;
            }
            public static uint rf1(uint r, uint c)
            {
                return r;
            }
            public static uint rf2(uint r, uint c)
            {
                return ((8+r-c)&3);
            }

            public static byte bval(uint x, uint n)
            {
                return (byte)((x) >> (int)(8 * (n)));
            }

            public static uint four_tables(uint x,uint[][] tab, Func<uint, uint, uint, uint> vf, Func<uint, uint, uint> rf, uint c)
            {
                return (uint)(  tab[0][bval(vf(x,0,c),rf(0,c))]
                        ^ tab[1][bval(vf(x,1,c),rf(1,c))]
                        ^ tab[2][bval(vf(x,2,c),rf(2,c))]
                        ^ tab[3][bval(vf(x,3,c),rf(3,c))]);
            }

            public static uint four_tables(uint[] x,uint[][] tab, Func<uint[], uint, uint, uint> vf, Func<uint, uint, uint> rf, uint c)
            {
                return (uint)(  tab[0][bval(vf(x,0,c),rf(0,c))]
                        ^ tab[1][bval(vf(x,1,c),rf(1,c))]
                        ^ tab[2][bval(vf(x,2,c),rf(2,c))]
                        ^ tab[3][bval(vf(x,3,c),rf(3,c))]);
            }

            public static uint ls_box(uint x, uint c)
            {
                return four_tables(x,t_fl,vf1,rf2,c);
            }

            // ALGORITHM_BYTE_ORDER == IS_LITTLE_ENDIAN 
            public static uint bytes2word(byte b0, byte b1, byte b2, byte b3)
            {
                uint val = 0;
                val += b0;
                val += (uint)(b1 << 8);
                val += (uint)(b2 << 16);
                val += (uint)(b3 << 24);
                return val;
            }

            // SAFE_IO
            public static uint word_in(byte[] x,int c)
            {
                return bytes2word(x[4*c], x[4*c+1], x[4*c+2], x[4*c+3]);
            }

            public static void word_out(byte[] x, uint c, uint v)
            {
                x[4*c] = bval(v,0);
                x[4*c+1] = bval(v,1);
                x[4*c+2] = bval(v,2);
                x[4*c+3] = bval(v,3);
            }

            // #define t_use(m,n) t_##m##n

            public static void ke4(uint[] k, uint i, uint[] ss)
            {  
                k[4*(i)+4] = ss[0] ^= ls_box(ss[3],3) ^ t_rc[i];
                k[4*(i)+5] = ss[1] ^= ss[0];
                k[4*(i)+6] = ss[2] ^= ss[1];
                k[4*(i)+7] = ss[3] ^= ss[2];
            }

            public static int aes_encrypt_key_128(byte[] key, AesEncryptContext cx)
            {   
                uint[] ss = new uint[4];

                cx.ks[0] = ss[0] = word_in(key, 0);
                cx.ks[1] = ss[1] = word_in(key, 1);
                cx.ks[2] = ss[2] = word_in(key, 2);
                cx.ks[3] = ss[3] = word_in(key, 3);

                uint i;
                for(i = 0; i < 9; ++i)
                    ke4(cx.ks, i, ss);

                ke4(cx.ks, 9, ss);
                cx.b[0] = 10 * 16;
                cx.b[1] = 0;
                cx.b[2] = 0;
                cx.b[3] = 0;

                return 0;
            }
            public static void si(uint[] y, byte[] x, uint[] k, int c)
            {
                y[c] = word_in(x, c) ^ k[c];
            }

            public static void so(byte[] y, uint[] x, uint c)
            {
                word_out(y, c, x[c]);
            }

            public static void state_in(uint[] y, byte[] x, uint[] k)
            {
                si(y,x,k,0);
                si(y,x,k,1);
                si(y,x,k,2);
                si(y,x,k,3);
            }

            public static void state_out(byte[] y, uint[] x)
            {
                so(y,x,0);
                so(y,x,1);
                so(y,x,2);
                so(y,x,3);
            }

            public static void round(Action<uint[], uint[], uint[], int , uint> rm, uint[] y, uint[] x, uint[] k, int k_offset)
            {
                rm(y,x,k, k_offset,0);
                rm(y,x,k, k_offset,1);
                rm(y,x,k, k_offset,2);
                rm(y,x,k, k_offset,3);
            }

            public static uint fwd_var(uint[] x, uint r, uint c)
            {
                return ( r == 0 ? ( c == 0 ? x[0] : c == 1 ? x[1] : c == 2 ? x[2] : x[3])
                : r == 1 ? ( c == 0 ? x[1] : c == 1 ? x[2] : c == 2 ? x[3] : x[0])
                : r == 2 ? ( c == 0 ? x[2] : c == 1 ? x[3] : c == 2 ? x[0] : x[1])
                :          ( c == 0 ? x[3] : c == 1 ? x[0] : c == 2 ? x[1] : x[2]));
            }

            public static void fwd_rnd(uint[] y, uint[] x, uint[] k, int k_offset, uint c)
            {
                y[c] = k[k_offset + c] ^ four_tables(x,t_fn,fwd_var,rf1,c);
            }

            public static void fwd_lrnd(uint[] y, uint[] x, uint[] k, int k_offset, uint c)
            {
                y[c] = k[k_offset + c] ^ four_tables(x,t_fl,fwd_var,rf1,c);
            }

            public static int aes_encrypt(byte[] in_, byte[] out_, AesEncryptContext cx)
            {   
                uint[] b0, b1;
                b0 = new uint[4];
                b1 = new uint[4];
                
                uint[] kp;
                
                if( cx.b[0] != 10 * 16 && cx.b[0] != 12 * 16 && cx.b[0] != 14 * 16 )
                    return -1;

                kp = cx.ks;
                state_in(b0, in_, kp);
                int kp_idx = 0;

                switch(cx.b[0])
                {
                    case 14 * 16:
                        round(fwd_rnd,  b1, b0, kp, kp_idx + 1 * N_COLS);
                        round(fwd_rnd,  b0, b1, kp, kp_idx + 2 * N_COLS);
                        kp_idx += 2 * N_COLS;
                        goto case 12 * 16;
                    case 12 * 16:
                        round(fwd_rnd,  b1, b0, kp, kp_idx + 1 * N_COLS);
                        round(fwd_rnd,  b0, b1, kp, kp_idx + 2 * N_COLS);
                        kp_idx += 2 * N_COLS;
                        goto case 10 * 16;
                    case 10 * 16:
                        round(fwd_rnd,  b1, b0, kp, kp_idx + 1 * N_COLS);
                        round(fwd_rnd,  b0, b1, kp, kp_idx + 2 * N_COLS);
                        round(fwd_rnd,  b1, b0, kp, kp_idx + 3 * N_COLS);
                        round(fwd_rnd,  b0, b1, kp, kp_idx + 4 * N_COLS);
                        round(fwd_rnd,  b1, b0, kp, kp_idx + 5 * N_COLS);
                        round(fwd_rnd,  b0, b1, kp, kp_idx + 6 * N_COLS);
                        round(fwd_rnd,  b1, b0, kp, kp_idx + 7 * N_COLS);
                        round(fwd_rnd,  b0, b1, kp, kp_idx + 8 * N_COLS);
                        round(fwd_rnd,  b1, b0, kp, kp_idx + 9 * N_COLS);
                        round(fwd_lrnd, b0, b1, kp, kp_idx + 10 * N_COLS);
                        break;
                }

                state_out(out_, b0);

                return 0;
            }
        }

        // https://github.com/alexeyvo/gladman_aes/blob/master/modes/cwc.c
        // https://github.com/alexeyvo/gladman_aes/blob/master/modes/cwc.h
        private class Cwc_Context
        {
            public byte[] ctr_val;
            public byte[] enc_ctr;
            public byte[] cwc_buf;
            public AesEncryptContext enc_ctx;
            public uint[] zval;
            public uint[] hash;
            public uint hdr_cnt;
            public uint txt_ccnt;
            public uint txt_acnt;

            public Cwc_Context()
            {
                Reset();
            }

            public void Reset()
            {
                ctr_val = new byte[Aes.AES_BLOCK_SIZE]; // uint[AES_BLOCK_SIZE/4] in lib
                enc_ctr = new byte[Aes.AES_BLOCK_SIZE]; // uint[AES_BLOCK_SIZE/4] in lib
                cwc_buf = new byte[Aes.AES_BLOCK_SIZE]; // uint[AES_BLOCK_SIZE/4] in lib
                enc_ctx = new AesEncryptContext();
                zval = new uint[4];
                hash = new uint[8];
                hdr_cnt = 0;
                txt_ccnt = 0;
                txt_acnt = 0;
            }
        }

        private class Cwc
        {
            static int ABLK_LEN = 12;
            static int CBLK_LEN = 16;
            static int BUF_ADRMASK = 3;
            static int BUF_INC = 4;
            static int CTR_POS = 12;
            static int CWC_CBLK_SIZE = Aes.AES_BLOCK_SIZE;
            static double   tm24 = 1.0 / (65536.0 * 256.0);
            static double   tm07 = 2.0 / 256.0;
            static double   tp17 = 2.0 * 65536.0;
            static double   tp59 = 2048.0 * 65536.0 * 65536.0 * 65536.0;
            static double   tp76 = 4096.0 * 65536.0 * 65536.0 * 65536.0 * 65536.0;

            public static void UIntToByte(uint val, byte[] array, int offset)
            {
                array[offset] = (byte)(val & 0xff);
                array[offset+1] = (byte)((val >> 8) & 0xff);
                array[offset+2] = (byte)((val >> 16) & 0xff);
                array[offset+3] = (byte)((val >> 24) & 0xff);
            }

            public static uint ByteToUInt(byte[] array, int offset)
            {
                uint val = 0;
                val += array[offset];
                val += (uint)(array[offset+1] << 8);
                val += (uint)(array[offset+2] << 16);
                val += (uint)(array[offset+3] << 24);
                return val;
            }

            public static int cwc_init_and_key(byte[] key, int key_len, Cwc_Context ctx)
            {
                if(key_len != 16 && key_len != 24 && key_len != 32)
                    return -1;

                {
                    ctx.Reset();
                    Aes.aes_encrypt_key(key, key_len, ctx.enc_ctx);

                    byte[] calcKey = new byte[16];
                    calcKey[0] = 0xc0;
                    Aes.aes_encrypt(calcKey, calcKey, ctx.enc_ctx);
                    uint val0 = ByteToUInt(calcKey, 0);
                    uint val1 = ByteToUInt(calcKey, 4);
                    uint val2 = ByteToUInt(calcKey, 8);
                    uint val3 = ByteToUInt(calcKey, 12);

                    uint uVar2 = val0;
                    val0 = val0 & 0xffffff7f;
                    val0 = val0 << 0x18 | (uVar2 >> 8 & 0xff) << 0x10 | (uVar2 >> 0x10 & 0xff) << 8 | uVar2 >> 0x18;
                    val1 = val1 << 0x18 | (val1 >> 8 & 0xff) << 0x10 | (val1 >> 0x10 & 0xff) << 8 | val1 >> 0x18;
                    val2 = val2 << 0x18 | (val2 >> 8 & 0xff) << 0x10 | (val2 >> 0x10 & 0xff) << 8 | val2 >> 0x18;
                    val3 = val3 << 0x18 | (val3 >> 8 & 0xff) << 0x10 | (val3 >> 0x10 & 0xff) << 8 | val3 >> 0x18;

                    ctx.zval[0] = val0;
                    ctx.zval[1] = val1;
                    ctx.zval[2] = val2;
                    ctx.zval[3] = val3;

                    return 0;
                }
            }

            public static int cwc_init_message(byte[] iv, int iv_len, Cwc_Context ctx)
            {
                ctx.ctr_val[0] = 0x80;
                for(int i = 0; i < 11; ++i)
                    ctx.ctr_val[i + 1] = iv[i];
                

                ctx.ctr_val[0xc] = 0;
                ctx.ctr_val[0xd] = 0;
                ctx.ctr_val[0xe] = 0;
                ctx.ctr_val[0xf] = 0;
                ctx.cwc_buf = new byte[16];
                ctx.hash = new uint[8];
                ctx.hdr_cnt = 0;
                ctx.txt_ccnt = 0;
                ctx.txt_acnt = 0;
                
                return 0;
            }

            public static int cwc_decrypt(byte[] data, int data_length, Cwc_Context ctx)
            {
                cwc_auth_data(data, data_length, ctx);
                cwc_crypt_data(data, data_length, ctx);
                return 0;
            }

            public static int cwc_auth_data(byte[] data, int data_len, Cwc_Context ctx)
            {
                uint cnt = 0;
                uint b_pos = (uint)(ctx.txt_acnt % ABLK_LEN);

                if(data_len == 0)
                    return 0;

                if (ctx.txt_acnt == 0) 
                {
                    uint pos = (uint)(ctx.hdr_cnt % ABLK_LEN);
                    if(pos != 0) 
                    {
                        while(pos < ABLK_LEN) 
                            ctx.cwc_buf[pos++] = 0;

                        do_cwc(ctx.cwc_buf, ctx);
                    }
                }

                Debug.Assert(ctx.cwc_buf[b_pos] <= 0);
                if(((data[ -ctx.cwc_buf[b_pos]]) & BUF_ADRMASK) == 0)
                {
                    while(cnt < data_len && (b_pos & BUF_ADRMASK) != 0)
                        ctx.cwc_buf[b_pos++] = data[cnt++];

                    while(cnt + BUF_INC <= data_len && b_pos <= ABLK_LEN - BUF_INC)
                    {
                        for(int i = 0; i < 4; i++)
                            ctx.cwc_buf[b_pos+i] = data[cnt+i];
                        cnt += (uint)BUF_INC;
                        b_pos += (uint)BUF_INC;
                    }

                    while(cnt + ABLK_LEN <= data_len)
                    {
                        do_cwc(ctx.cwc_buf, ctx);
                        System.Buffer.BlockCopy(data, (int)cnt, ctx.cwc_buf, 0, (int)ABLK_LEN);
                        //memcpy(ctx.cwc_buf, data + cnt, ABLK_LEN);
                        cnt += (uint)ABLK_LEN;
                    }
                }
                else
                {
                    while(cnt < data_len && b_pos < ABLK_LEN)
                        ctx.cwc_buf[b_pos++] = data[cnt++];

                    while(cnt + ABLK_LEN <= data_len)
                    {
                        do_cwc(ctx.cwc_buf, ctx);
                        System.Buffer.BlockCopy(data, (int)cnt, ctx.cwc_buf, 0, (int)ABLK_LEN);
                        //memcpy(ctx.cwc_buf, data + cnt, ABLK_LEN);
                        cnt += (uint)ABLK_LEN;
                    }
                }

                while(cnt < data_len)
                {
                    if(b_pos == ABLK_LEN)
                    {
                        do_cwc(ctx.cwc_buf, ctx);
                        b_pos = 0;
                    }
                    ctx.cwc_buf[b_pos++] = data[cnt++];
                }

                if(b_pos == ABLK_LEN)
                    do_cwc(ctx.cwc_buf, ctx);

                ctx.txt_acnt += cnt;
                return 0;
            }

            public static int cwc_crypt_data(byte[] data, int data_len, Cwc_Context ctx)
            {
                uint cnt = 0;
                uint b_pos = (uint)(ctx.txt_ccnt % CBLK_LEN);

                if(data_len == 0)
                    return 0;

                Debug.Assert(ctx.enc_ctr[b_pos] <= 0);
                if(((data[-ctx.enc_ctr[b_pos]]) & BUF_ADRMASK) == 0)
                {
                    if(b_pos != 0)
                    {
                        while(cnt < data_len && (b_pos & BUF_ADRMASK) != 0)
                            data[cnt++] ^= ctx.enc_ctr[b_pos++];

                        while(cnt + BUF_INC <= data_len && b_pos <= CBLK_LEN - BUF_INC)
                        {
                            for(int i = 0; i < 4; i++)
                                data[cnt+i] ^= ctx.enc_ctr[b_pos+i];
                            cnt += (uint)BUF_INC;
                            b_pos += (uint)BUF_INC;
                        }
                    }

                    while(cnt + CBLK_LEN <= data_len)
                    {
                        be_inc(ctx.ctr_val, CTR_POS);
                        Aes.aes_encrypt(ctx.ctr_val, ctx.enc_ctr, ctx.enc_ctx);
                        xor_block_aligned(data, cnt, data, cnt, ctx.enc_ctr);
                        cnt += (uint)CBLK_LEN;
                    }
                }
                else
                {
                    if(b_pos != 0)
                        while(cnt < data_len && b_pos < CBLK_LEN)
                            data[cnt++] ^= ctx.enc_ctr[b_pos++];

                    while(cnt + CBLK_LEN <= data_len)
                    {
                        be_inc(ctx.ctr_val, CTR_POS);
                        Aes.aes_encrypt(ctx.ctr_val, ctx.enc_ctr, ctx.enc_ctx);
                        xor_block(data, cnt, data, cnt, ctx.enc_ctr);
                        cnt += (uint)CBLK_LEN;
                    }
                }

                while(cnt < data_len)
                {
                    if(b_pos == CBLK_LEN || b_pos == 0)
                    {
                        be_inc(ctx.ctr_val, CTR_POS);
                        Aes.aes_encrypt(ctx.ctr_val, ctx.enc_ctr, ctx.enc_ctx);
                        b_pos = 0;
                    }
                    data[cnt++] ^= ctx.enc_ctr[b_pos++];
                }

                ctx.txt_ccnt += cnt;
                return 0;
            }

            public static uint bswap_32(uint in_val)
            {
                uint newval = in_val << 0x18 | (in_val >> 8 & 0xff) << 0x10 | (in_val >> 0x10 & 0xff) << 8 | in_val >> 0x18;
                return newval;
            }

            public static void bswap32_block(uint[] d, uint[] s)
            {
                d[0] = bswap_32(s[0]); 
                d[1] = bswap_32(s[1]);
                d[2] = bswap_32(s[2]); 
                d[3] = bswap_32(s[3]);
            }


            /* add multiple length unsigned values in big endian form   */
            /* little endian long words in big endian word order        */
            public static void add_4(uint[] l, uint[] r, uint r_offset)
            {   
                uint   ss, cc;

                ss = l[3] + r[r_offset+3];
                cc = (uint)(ss < l[3] ? 1 : 0);
                l[3] = ss;

                ss = l[2] + r[r_offset+2] + cc;
                cc = (uint)(ss < l[2] ? 1 : ss > l[2] ? 0 : cc);
                l[2] = ss;

                ss = l[1] + r[r_offset+1] + cc;
                cc = (uint)(ss < l[1] ? 1 : ss > l[1] ? 0 : cc);
                l[1] = ss;

                l[0] += r[r_offset+0] + cc;
            }

            /* multiply multiple length unsigned values in big endian form  */
            /* little endian long words in big endian word order            */

            public static void mlt_4(uint[] r, uint[] a, uint[] b)
            {   
                ulong ch, cl, sm;
                int     i, j, k;

                for(i = 0, cl = 0; i < 8; ++i)
                {
                    /* number of terms in sum   */
                    k = (i < 3 ? 0 : i - 3);

                    for(j = k, ch = 0; j <= i - k; ++j)
                    {
                        sm = (ulong)a[3 - j] * b[3 - i + j];
                        cl += (uint)sm;
                        ch += (sm >> 32);
                    }

                    r[7 - i] = (uint)cl;
                    cl = (cl >> 32) + ch;
                }
            }

            // USE_LONGS implementation
            /* Carter-Wegman hash iteration on 12 bytes of data */
            public static void do_cwc(byte[] in_data, Cwc_Context ctx)
            {   
                uint pt_ptr = (uint)(CWC_CBLK_SIZE >> 2);
                uint[] data = new uint[4];

                /* put big endian 32-bit items into little endian order     */
                data[3] = bswap_32(ByteToUInt(in_data, 2 * 4));
                data[2] = bswap_32(ByteToUInt(in_data, 1 * 4));
                data[1] = bswap_32(ByteToUInt(in_data, 0 * 4));
                data[0] = 0;

                /* add current hash value into the current data block   */
                add_4(data, ctx.hash, 0);

                /* multiply by the hash key in Z                        */
                mlt_4(ctx.hash, data, ctx.zval);

                /* we now want to find the remainder when divided by    */
                /* (2^127 - 1).  If hash = 2^128 * hi + lo, we can see  */
                /* that hash = (2^127 - 1) * 2 * hi + 2 * hi + lo, so   */
                /* we can set the 128 bit remainder as 2 * hi + lo      */

                add_4(ctx.hash, ctx.hash, 0);/* 2 * hi - if top bit = 1  */
                if((ctx.hash[pt_ptr] & 0x80000000) != 0)    /* another 2^127-1 has to be    */
                {                       /* subtracted from the result   */
                    ctx.hash[pt_ptr] &= 0x7fffffff;
                    ctx.hash[pt_ptr-1] += 1;
                }

                add_4(ctx.hash, ctx.hash, pt_ptr);       /* 2 * hi + lo - adjust the */
                if((ctx.hash[0] & 0x80000000) != 0) /* result again (as above)  */
                {
                    ctx.hash[0] &= 0x7fffffff;
                    be_inc(ctx.hash, 0);
                }
            }

            public static void be_inc(byte[] x, int n)
            {
                for(int i = 3; i >= 0; i-- )
                {
                    ++x[n + i];
                    if(x[n + i] != 0)
                        break;
                }
                    
               // (((x)[n+3])) == 0) && ((++((x)[n+2])) == 0) && ((++((x)[n+1])) == 0) && ((++((x)[n]) == 0));
            }
            public static void be_inc(uint[] x, int n)
            {
                for(int i = 3; i >= 0; i-- )
                {
                    ++x[n + i];
                    if(x[n + i] != 0)
                        break;
                }
                    
               // (((x)[n+3])) == 0) && ((++((x)[n+2])) == 0) && ((++((x)[n+1])) == 0) && ((++((x)[n]) == 0));
            }

            public static void f_xor(int n, byte[] r, uint r_start, byte[] p, uint p_start, byte[] q, int c)
            {
                //r[n] = c(p[n] ^ q[n])
                if(c == 32)
                {
                    uint val1 = ByteToUInt(p, (int)(p_start + n * 4));
                    uint val2 = ByteToUInt(q, (int)(n * 4));
                    uint res = (uint)(val1 ^ val2);
                    UIntToByte(res, r, (int)(r_start + n * 4));
                }
                else if(c == 8)
                {
                    r[r_start+n] = (byte)(p[p_start+n] ^ q[n]);
                }
                else Debug.Assert(false);
            }

            public static void Rep3U4(Action<int, byte[], uint, byte[], uint, byte[], int> f, byte[] r, uint r_start, byte[] x, uint x_start, byte[] y, int c)
            {
                for(int i = 0; i < 4; i++)
                {
                    f( i,r,r_start, x, x_start,y,c);
                }
            }

            public static void Rep3U16(Action<int, byte[], uint, byte[], uint, byte[], int> f, byte[] r, uint r_start, byte[] x, uint x_start, byte[] y, int c)
            {
                for(int i = 0; i < 16; i++)
                {
                    f( i,r, r_start,x, x_start,y,c);
                }
            }

            public static void xor_block_aligned(byte[] r, uint r_start, byte[] p, uint p_start, byte[] q)
            {
                Rep3U4(f_xor, r, r_start, p, p_start, q, /*UNIT_VAL*/32);
            }

            public static void xor_block(byte[] r, uint r_start, byte[] p, uint p_start, byte[] q)
            {
                Rep3U16(f_xor, r, r_start, p, p_start, q, 8);
            }

            public static int cwc_compute_tag(byte[] tag, int tag_len, Cwc_Context ctx)
            {
                uint pos;
                uint[] hh = new uint[4];
                byte[] hhb = new byte[4 * 4];

                if(ctx.txt_acnt != ctx.txt_ccnt && ctx.txt_ccnt > 0)
                    return -1;

                if (ctx.txt_acnt == 0) 
                {
                    pos = (uint)(ctx.hdr_cnt % ABLK_LEN);
                    if(pos != 0) 
                    {
                        while(pos < ABLK_LEN) 
                            ctx.cwc_buf[pos++] = 0;

                        do_cwc(ctx.cwc_buf, ctx);
                    }
                }

                pos = (uint)(ctx.txt_acnt % ABLK_LEN);
                if(pos != 0)
                {
                    while(pos < ABLK_LEN)
                        ctx.cwc_buf[pos++] = 0;

                    do_cwc(ctx.cwc_buf, ctx);
                }

                /*  For 64-bit data lengths:
                hh[0] = (ctx.hdr_cnt >> 32);
                hh[1] = (ctx.hdr_cnt & 0xffffffff);
                hh[2] = (ctx.txt_acnt >> 32);
                hh[3] = (ctx.txt_acnt & 0xffffffff);
                */
                hh[0] = 0;
                hh[1] = ctx.hdr_cnt;
                hh[2] = 0;
                hh[3] = ctx.txt_acnt;
                add_4(ctx.hash, hh, 0);

                if((ctx.hash[0] & 0x80000000) != 0)
                {
                    ctx.hash[0] &= 0x7fffffff;
                    be_inc(ctx.hash, 0);
                }

                hh[0] = ctx.hash[0];
                hh[1] = ctx.hash[1];
                hh[2] = ctx.hash[2];
                hh[3] = ctx.hash[3];

                bswap32_block(hh, hh);

                UIntToByte(hh[0], hhb, 0);
                UIntToByte(hh[1], hhb, 4);
                UIntToByte(hh[2], hhb, 8);
                UIntToByte(hh[3], hhb, 12);

                Aes.aes_encrypt(hhb, hhb, ctx.enc_ctx);

                System.Buffer.BlockCopy(ctx.ctr_val, 0, ctx.enc_ctr, 0, Aes.AES_BLOCK_SIZE);
                //memcpy(ctx.enc_ctr, ctx.ctr_val, AES_BLOCK_SIZE);
                ctx.enc_ctr[CTR_POS] = 0;
                ctx.enc_ctr[CTR_POS+1] = 0;
                ctx.enc_ctr[CTR_POS+2] = 0;
                ctx.enc_ctr[CTR_POS+3] = 0;
                Aes.aes_encrypt(ctx.enc_ctr, ctx.enc_ctr, ctx.enc_ctx);

                for(pos = 0; pos < tag_len; ++pos)
                    tag[pos] = (byte)(hhb[pos] ^ ctx.enc_ctr[pos]);
                return (ctx.txt_ccnt == ctx.txt_acnt ? 0 : -1);
            }
        }

        private class DeDecryptAES
        {
            Cwc_Context cwc_context;
            byte[] k = new byte[28];
            byte[] k2 = new byte[256];
            DeRandomXSadd randXSadd;

            public DeDecryptAES()
            {
                cwc_context = null;
                randXSadd = new DeRandomXSadd();
                System.DateTime time = System.DateTime.Now;
                randXSadd.SetSeed(0); // todo rand
            }

            public bool Initialize(Key _k)
            {
                if(cwc_context != null)
                    return false;
                cwc_context = new Cwc_Context();
                randXSadd.GetRandBytes(k2, 0x10);
                for(int i = 0; i < 16; i++)
                    k[i] = (byte)(k2[i] ^ _k.key[i]);
                return true;
            }

            public bool BeginDecrypt(byte[] message)
            {
                if(cwc_context == null)
                {
                    Debug.LogError("DeDecryptAES no initialized");
                    return false;
                }
                byte[] key = new byte[16];
                for(int i = 0; i < 16; i++)
                    key[i] = (byte)(k2[i] ^ k[i]);

                int res = Cwc.cwc_init_and_key(key, 0x10, cwc_context);
                if(res == 0)
                {
                    res = Cwc.cwc_init_message(message, 0xb, cwc_context);
                    if(res == 0)
                        return true;
                }
                Debug.LogError("DeDecryptAES cwc: failed to initialize");
                return false;
            }

            public bool DecryptData(byte[] data, int size)
            {
                if(cwc_context == null)
                {
                    Debug.LogError("DeDecryptAES no initialized");
                    return false;
                }
                return Cwc.cwc_decrypt(data, size, cwc_context) == 0;
            }

            public bool CheckSignature(byte[] signature)
            {
                if(cwc_context == null)
                {
                    Debug.LogError("DeDecryptAES no initialized");
                    return false;
                }
                byte[] calcSignature = new byte[16];
                int res = Cwc.cwc_compute_tag(calcSignature, 16, cwc_context);
                if(res != 0)
                {
                    Debug.LogError("DeDecryptAES: failed to sign in");
                    return false;
                }
                for(int i = 0; i < 16; i++)
                {
                    if(signature[i] != calcSignature[i])
                    {
                        Debug.LogError("DeDecryptAES: signature don't match");
                        return false;
                    }
                }
                return true;
            }
        }

        private class DeSecureFile
        {
            public bool ReadFile(string filePath, DeDecryptAES aes, DeRingBuffer ringBuffer)
            {
                byte[] fileData = System.IO.File.ReadAllBytes(filePath);
                DeRingBuffer readBuffer = new DeRingBuffer();
                readBuffer.bytes = fileData;
                return DecodeFile(readBuffer, aes, ringBuffer);
            }

            public bool DecodeFile(DeRingBuffer readBuffer, DeDecryptAES aes, DeRingBuffer writeBuffer)
            {
                if(!(readBuffer.bytes[0] == 'D' && readBuffer.bytes[1] == 'S' && readBuffer.bytes[2] == 'F' && readBuffer.bytes[3] == 'E'))
                {
                    Debug.LogError("File header error");
                    return false;
                }
                readBuffer.currentPos += 4;
                int size = readBuffer.bytes.Length - 4 - 0x1b;
                writeBuffer.bytes = new byte[size];
                byte[] message = new byte[0xb];
                if(readBuffer.Read(message, 0xb) != 0xb)
                {
                    Debug.LogError("Message size error");
                    return false;
                }
                byte[] signature = new byte[0x10];
                if(readBuffer.Read(signature, 0x10) != 0x10)
                {
                    Debug.LogError("signature size error");
                    return false;
                }
                if(readBuffer.Read(writeBuffer.bytes, size) != size)
                {
                    Debug.LogError("fileData size error");
                    return false;
                }
                aes.BeginDecrypt(message);
                aes.DecryptData(writeBuffer.bytes, size);
                return aes.CheckSignature(signature);
            }
        }

        private class Decryptor
        {
            bool AesInitialized;
            DeDecryptAES aes;

            public Decryptor()
            {
                aes = new  DeDecryptAES();
                // 0x34 = 0;
            }

            public bool Initialize(byte[] seed1, byte[] seed2, byte[] seed3)
            {
                Key k = new Key();
                string s1 = BitConverter.ToString(seed1).Replace("-","");
                string s2 = BitConverter.ToString(seed2).Replace("-","");
                string s3 = BitConverter.ToString(seed3).Replace("-","");
                bool r = KeyGenerator.Gen(k, s1, s2, s3);
                if(!r)
                {
                    Debug.LogError("Error generating key");
                    return false;
                }
                if(!AesInitialized)
                    AesInitialized = aes.Initialize(k);
                
                return AesInitialized;
            }

            public bool DecryptFile(DeRingBuffer ringBuffer, string filePath)
            {
                DeSecureFile file = new DeSecureFile();
                return file.ReadFile(filePath, aes, ringBuffer);
            }
        }

        private class DeRingBuffer
        {
            public byte[] bytes;
            public int currentPos = 0;

            public int Read(byte[] outBuffer, int size)
            {
                size = Math.Min(size, bytes.Length - currentPos);
                System.Buffer.BlockCopy(bytes, currentPos, outBuffer, 0, size);
                currentPos += size;
                return size;
            }
        }

        private class DecryptManager
        {
            public Decryptor decryptor;
            Dictionary<uint, DecryptedResult> requests = new Dictionary<uint, DecryptedResult>();
            uint counter = 0;

            public bool Initialize(byte[] seed1, byte[] seed2, byte[] seed3)
            {
                decryptor = new Decryptor();
                bool res = decryptor.Initialize(seed1, seed2, seed3);
                if(!res)
                    return false;
                // stuff with ringbuffer
                return true;
            }

            public uint Request(string filePath)
            {
                uint idx = ++counter;
                requests[idx] = new DecryptedResult();
                requests[idx].handle = idx;
                ExecRequest(filePath, requests[idx]); // async in original dll
                return idx;
            }

            public uint ExecRequest(string filePath, DecryptedResult request)
            {
                request.ringBuffer = new DeRingBuffer();
                request.isSuccess = decryptor.DecryptFile(request.ringBuffer, filePath);
                if(request.isSuccess)
                {
                    request.bytes = request.ringBuffer.bytes;
                }
                return 0;
            }

            public void GetResults(DecryptedResultList result)
            {
                foreach(var item in requests)
                {
                    result.results.Add(item.Value);
                }
            }
        }

        private class DecryptedResult
        {
            public uint handle; // 0x0
            public bool isSuccess; // 0x4
            public uint size; // 0x8
            public byte[] bytes; // 0xC

            public DeRingBuffer ringBuffer;
        }

        private class DecryptedResultList
        {
            public uint count; // 0x0
            public List<DecryptedResult> results = new List<DecryptedResult>(); // 0x4
        }

        static private DecryptManager decryptManager;


        private static bool isInitialized; // 0x0
        private static Dictionary<uint, LoadRequest> loadRequestDict; // 0x4

        // // RVA: 0x2BAE368 Offset: 0x2BAE368 VA: 0x2BAE368
        private static /*extern */bool dsfd_initialize(byte[] seed1, byte[] seed2, byte[] seed3/*[In] IntPtr seed1, [In] IntPtr seed2, [In] IntPtr seed3*/) 
        { 
            // Call lib dsfd dsfd_initialize

            // stuff with the array...
            decryptManager = new DecryptManager();
            bool res = decryptManager.Initialize(seed1, seed2, seed3);
            return res;
        }

        // // RVA: 0x2BAE488 Offset: 0x2BAE488 VA: 0x2BAE488
        // private static extern void dsfd_finalize() { }

        // // RVA: 0x2BAE578 Offset: 0x2BAE578 VA: 0x2BAE578
        // private static extern void dsfd_release_results([In] DsfdLoader.DecryptedResultList result) { }

        // // RVA: 0x2BAE690 Offset: 0x2BAE690 VA: 0x2BAE690
        private static /*extern */uint dsfd_single(string filePath)
        {
            // Call lib dsfd  dsfd_single
            return decryptManager.Request(filePath);
        }

        // // RVA: 0x2BAE7B0 Offset: 0x2BAE7B0 VA: 0x2BAE7B0
        // private static extern uint dsfd_multiple(uint[] handles, string[] filePaths, int size) { }

        // // RVA: 0x2BAE998 Offset: 0x2BAE998 VA: 0x2BAE998
        private static /*extern */DsfdLoader.DecryptedResultList dsfd_poll_results()
        {
            DsfdLoader.DecryptedResultList result = new DsfdLoader.DecryptedResultList();
            // call dsfd_poll_results
            decryptManager.GetResults(result);

            return result;
        }

        // // RVA: 0x2BAEAA8 Offset: 0x2BAEAA8 VA: 0x2BAEAA8
        public static bool Initialize(byte[] seed1, byte[] seed2, byte[] seed3, bool shouldShowLogOnEditor = true)
        {
            loadRequestDict = new Dictionary<uint, LoadRequest>();
            if(seed1.Length == 0x10 && seed2.Length == 0x10 && seed3.Length == 0x10)
            {
                if(isInitialized)
                {
                    Debug.LogWarning("StringLiteral_8278 (dsfd alread initialzed ?");
                    return false;
                }
                isInitialized = true;
                bool res = dsfd_initialize(seed1, seed2, seed3);
                if(res)
                    return true;
            }
            Debug.LogError("Size wrong or init fail");
            return false;
        }

        // // RVA: 0x2BAEF20 Offset: 0x2BAEF20 VA: 0x2BAEF20
        // public static void Terminate() { }

        // // RVA: 0x2BAF080 Offset: 0x2BAF080 VA: 0x2BAF080
        public static DsfdLoader.ILoadRequest LoadFile(string filePath)
        {
            if(isInitialized)
            {
                uint res = dsfd_single(filePath);
                if(res != 0)
                {
                    loadRequestDict[res] = new LoadRequest(filePath);
                    Update(); // for update since we don't do async
                    return loadRequestDict[res];
                }
            }
            return null;
        }

        // // RVA: 0x2BAF274 Offset: 0x2BAF274 VA: 0x2BAF274
        // public static DsfdLoader.IMultiLoadRequest LoadFiles(string[] filePaths) { }

        // // RVA: 0x2BAF708 Offset: 0x2BAF708 VA: 0x2BAF708
        public static void Update()
        {
            DsfdLoader.DecryptedResultList pollList = dsfd_poll_results();
            foreach(var i in pollList.results)
            {
                LoadRequest item = null;
                if(loadRequestDict.TryGetValue(i.handle, out item))
                {
                    item.FinishRequest(i.isSuccess, i.bytes);
                }
            }

        }
    }
}
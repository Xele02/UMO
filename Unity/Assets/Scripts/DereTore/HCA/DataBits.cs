using System.Runtime.CompilerServices;

namespace DereTore.Exchange.Audio.HCA {
    internal sealed class DataBits {

        static DataBits() {
        }

        public DataBits(byte[] data, uint size) {
			Set(data, size);
        }

		public void Set(byte[] data, uint size)
		{
			_data = data;
			_size = size * 8 - 16;
			_bit = 0;
		}

		public int CheckBit(int bitSize) {
            var v = 0;

            if (_bit + bitSize <= _size) {
                var i = _bit >> 3;
                v = SafeAccessData(i);
                v = (v << 8) | SafeAccessData(i + 1);
                v = (v << 8) | SafeAccessData(i + 2);
                v &= Mask[_bit & 7];
                v >>= 24 - (_bit & 7) - bitSize;
            }

            return v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetBit(int bitSize) {
            var v = CheckBit(bitSize);
            _bit += bitSize;
            return v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddBit(int bitSize) {
            _bit += bitSize;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private byte SafeAccessData(int index) {
            if (0 <= index && index < _data.Length) {
                return _data[index];
            } else {
                return 0;
            }
        }

        private static readonly int[] Mask = { 0xffffff, 0x7fffff, 0x3fffff, 0x1fffff, 0x0fffff, 0x07ffff, 0x03ffff, 0x01ffff };

        private byte[] _data;
        private uint _size;
        private int _bit;

    }
}

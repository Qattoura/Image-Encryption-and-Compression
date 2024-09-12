using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ImageEncryptCompress
{
    //1
    [Serializable]
    public struct BinaryConvert
    {
        public byte[] red, green, blue;
        public Dictionary<byte, int> freq_red, freq_green, freq_blue;
        public int remain_red, remain_green, remain_blue, row, column, tap;
        public String seed;
    }

    [Serializable]
    public struct BinaryConvertForEncode
    {
        public int  tap;
        public String seed;
    }

    //2
    internal class Node
    {
        public int freq;
        public Node left_node;
        public Node right_node;

        public Node(Node left, Node right)
        {
            left_node = left;
            right_node = right;
            freq = (left_node?.freq ?? 0) + (right_node?.freq ?? 0);
        }
    }

    //3
    internal class Leaf : Node
    {
        public int color { get; }



        public Leaf(int colour, int frequency) : base(null, null)
        {
            freq = frequency;
            color = colour;
        }

    }


    //4

    internal class Huff
    {
        public int row;
        public int column;
        Node root_red;
        Node root_green;
        Node root_blue;
        public RGBPixel[,] arr;
        public Dictionary<byte, int> freq_red = new Dictionary<byte, int>();
        public Dictionary<byte, int> freq_green = new Dictionary<byte, int>();
        public Dictionary<byte, int> freq_blue = new Dictionary<byte, int>();
        public Dictionary<int, string> huffCodes_red = new Dictionary<int, string>();
        public Dictionary<int, string> huffCodes_green = new Dictionary<int, string>();
        public Dictionary<int, string> huffCodes_blue = new Dictionary<int, string>();
        public string final_encoded_red;
        public string final_encoded_green;
        public string final_encoded_blue;


        public Huff(RGBPixel[,] color_arr)
        {

            arr = color_arr;
            row = arr.GetLength(0);
            column = arr.GetLength(1);
            fillfreq();
            final_encoded_red = "";
            final_encoded_green = "";
            final_encoded_blue = "";
        }

        public Huff()
        {



        }

        public void fillfreq()
        {

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {

                    // red freq
                    if (freq_red.ContainsKey(arr[i, j].red))
                    {
                        freq_red[arr[i, j].red]++;

                    }
                    else
                    {
                        freq_red.Add(arr[i, j].red, 1);
                    }


                    // green freq
                    if (freq_green.ContainsKey(arr[i, j].green))
                    {
                        freq_green[arr[i, j].green]++;

                    }
                    else
                    {
                        freq_green.Add(arr[i, j].green, 1);
                    }


                    // blue freq
                    if (freq_blue.ContainsKey(arr[i, j].blue))
                    {
                        freq_blue[arr[i, j].blue]++;
                    }
                    else
                    {
                        freq_blue.Add(arr[i, j].blue, 1);
                    }


                }
            }
            encode(false);
        }

        public void encode(bool decompress)
        {
            MinPriorityQueue<int, Node> queue_red = new MinPriorityQueue<int, Node>();
            MinPriorityQueue<int, Node> queue_green = new MinPriorityQueue<int, Node>();
            MinPriorityQueue<int, Node> queue_blue = new MinPriorityQueue<int, Node>();
            foreach (var item in freq_red)
            {
                int key = item.Key;
                int value = item.Value;

                Leaf l = new Leaf(key, value);
                queue_red.Enqueue(value, l);
            }

            while (queue_red.Size() > 1)
            {
                Node n = new Node(queue_red.Dequeue(), queue_red.Dequeue());
                queue_red.Enqueue(n.freq, n);
            }
            root_red = queue_red.Dequeue();

            //green
            foreach (var item in freq_green)
            {
                int key = item.Key;
                int value = item.Value;

                Leaf l = new Leaf(key, value);
                queue_green.Enqueue(value, l);
            }

            while (queue_green.Size() > 1)
            {
                Node n = new Node(queue_green.Dequeue(), queue_green.Dequeue());
                queue_green.Enqueue(n.freq, n);
            }
            root_green = queue_green.Dequeue();

            //blue
            foreach (var item in freq_blue)
            {
                int key = item.Key;
                int value = item.Value;

                Leaf l = new Leaf(key, value);
                queue_blue.Enqueue(value, l);
            }

            while (queue_blue.Size() > 1)
            {
                Node n = new Node(queue_blue.Dequeue(), queue_blue.Dequeue());
                queue_blue.Enqueue(n.freq, n);
            }
            root_blue = queue_blue.Dequeue();

            if (!decompress)
            {
                generateHuffCode(root_red, "", 1);
                generateHuffCode(root_green, "", 2);
                generateHuffCode(root_blue, "", 3);
            }
        }

        public void generateHuffCode(Node node, string color_code, int color)
        {


            if (node is Leaf leaf)
            {
                if (color_code.Equals(""))
                    color_code = "0";


                if (color == 1)
                {
                    huffCodes_red.Add(leaf.color, color_code);

                }

                else if (color == 2)
                {
                    huffCodes_green.Add(leaf.color, color_code);

                }

                else if (color == 3)
                {
                    huffCodes_blue.Add(leaf.color, color_code);

                }
                return;
            }

            generateHuffCode(node.left_node, (color_code + "0"), color);
            generateHuffCode(node.right_node, (color_code + "1"), color);
        }

        public void replace_values()
        {
            StringBuilder finalEncodedRed = new StringBuilder();
            StringBuilder finalEncodedGreen = new StringBuilder();
            StringBuilder finalEncodedBlue = new StringBuilder();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    byte red = arr[i, j].red;
                    byte green = arr[i, j].green;
                    byte blue = arr[i, j].blue;

                    // Append Huffman codes
                    finalEncodedRed.Append(huffCodes_red[red]);
                    finalEncodedGreen.Append(huffCodes_green[green]);
                    finalEncodedBlue.Append(huffCodes_blue[blue]);
                }
            }

            final_encoded_red = finalEncodedRed.ToString();
            final_encoded_green = finalEncodedGreen.ToString();
            final_encoded_blue = finalEncodedBlue.ToString();

        }

        public void decompress()
        {
            arr = new RGBPixel[row, column];


            Node current_red = root_red;
            int len_red = final_encoded_red.Length;
            int i = 0, j = 0;
            for (int k = 0; k < len_red; k++)
            {

                if (current_red is Leaf leaff)
                {
                    arr[i, j].red = (byte)leaff.color;
                    j++;
                    current_red = root_red;

                    if (j == column)
                    {
                        j = 0;
                        i++;
                    }
                    if (i == row)
                    {
                        break;
                    }
                    continue;
                }
                current_red = final_encoded_red[k] == '0' ? current_red.left_node : current_red.right_node;
                if (current_red is Leaf leaf)
                {


                    arr[i, j].red = (byte)leaf.color;
                    j++;
                    current_red = root_red;

                    if (j == column)
                    {
                        j = 0;
                        i++;
                    }
                    if (i == row)
                    {
                        break;
                    }
                }
            }

            i = 0;
            j = 0;
            Node current_green = root_green;
            int len_green = final_encoded_green.Length;
            for (int k = 0; k < len_green; k++)
            {

                if (current_green is Leaf leaff)
                {
                    arr[i, j].green = (byte)leaff.color;
                    j++;
                    current_green = root_green;

                    if (j == column)
                    {
                        j = 0;
                        i++;
                    }
                    if (i == row)
                    {
                        break;
                    }
                    continue;
                }
                current_green = final_encoded_green[k] == '0' ? current_green.left_node : current_green.right_node;
                if (current_green is Leaf leaf)
                {


                    arr[i, j].green = (byte)leaf.color;
                    j++;
                    current_green = root_green;

                    if (j == column)
                    {
                        j = 0;
                        i++;
                    }
                    if (i == row)
                    {
                        break;
                    }
                }
            }


            i = 0;
            j = 0;
            Node current_blue = root_blue;
            int len_blue = final_encoded_blue.Length;
            for (int k = 0; k < len_blue; k++)
            {

                if (current_blue is Leaf leaff)
                {
                    arr[i, j].blue = (byte)leaff.color;
                    j++;
                    current_blue = root_blue;

                    if (j == column)
                    {
                        j = 0;
                        i++;
                    }
                    if (i == row)
                    {
                        break;
                    }
                    continue;
                }
                current_blue = final_encoded_blue[k] == '0' ? current_blue.left_node : current_blue.right_node;
                if (current_blue is Leaf leaf)
                {


                    arr[i, j].blue = (byte)leaf.color;
                    j++;
                    current_blue = root_blue;

                    if (j == column)
                    {
                        j = 0;
                        i++;
                    }
                    if (i == row)
                    {
                        break;
                    }
                }
            }


        }

        public void deserializeSteps()
        {
            encode(true);
            decompress();

        }


    }

    //5
    internal class Files
    {

        string fe_red, fe_green, fe_blue;
        byte[] finalData_red, finalData_green, finalData_blue;
        public BinaryConvert myObject;
        public BinaryConvertForEncode bc;

        public Files(Huff huffman, string seed, int tap)
        {
          
            myObject = new BinaryConvert();
            myObject.seed = seed;
            myObject.tap = tap;
            fe_red = huffman.final_encoded_red;
            fe_green = huffman.final_encoded_green;
            fe_blue = huffman.final_encoded_blue;

            myObject.remain_red = 8 - (huffman.final_encoded_red.Length % 8);
            myObject.remain_green = 8 - (huffman.final_encoded_green.Length % 8);
            myObject.remain_blue = 8 - (huffman.final_encoded_blue.Length % 8);

            complet8(myObject.remain_red, myObject.remain_green, myObject.remain_blue);

            strToBit(fe_red, fe_green, fe_blue);

            myObject.red = finalData_red;
            myObject.green = finalData_green;
            myObject.blue = finalData_blue;

            myObject.freq_red = huffman.freq_red;
            myObject.freq_blue = huffman.freq_blue;
            myObject.freq_green = huffman.freq_green;

            myObject.row = huffman.row;
            myObject.column = huffman.column;

            save(myObject);

        }

        public Files(BinaryConvertForEncode encode)
        {
            bc = encode;
            save_encode(bc);

        }
        public float Ratio()
        {
            float ratio = 0.0f;

            int original = (myObject.row * myObject.column) * 3;
            int compressed = myObject.red.Length + myObject.green.Length + myObject.blue.Length;

            ratio = (float)compressed / (float)original;

            return ratio*100;
        }

        void complet8(int remain_red, int remain_green, int remain_blue)
        {
            if (remain_red != 8)
            {
                for (int i = 0; i < remain_red; i++)
                {

                    fe_red += "0";
                }
            }


            if (remain_green != 8)
            {
                for (int i = 0; i < remain_green; i++)
                {
                    fe_green += "0";
                }
            }

            if (remain_blue != 8)
            {
                for (int i = 0; i < remain_blue; i++)
                {
                    fe_blue += "0";
                }
            }


        }

        void strToBit(string binaryString_red, string binaryString_green, string binaryString_blue)
        {
            int numBytes_red = (binaryString_red.Length + 7) / 8;
            byte[] binaryData_red = new byte[numBytes_red];
            for (int i = 0; i < numBytes_red; i++)
            {
                int startIndex = Math.Max(0, binaryString_red.Length - (i + 1) * 8);
                string byteString = binaryString_red.Substring(startIndex, Math.Min(8, binaryString_red.Length - startIndex));
                binaryData_red[i] = Convert.ToByte(byteString, 2);
            }

            finalData_red = binaryData_red;

            /////////////////////////////////////
            ///

            int numBytes_green = (binaryString_green.Length + 7) / 8;
            byte[] binaryData_green = new byte[numBytes_green];
            for (int i = 0; i < numBytes_green; i++)
            {
                int startIndex = Math.Max(0, binaryString_green.Length - (i + 1) * 8);
                string byteString = binaryString_green.Substring(startIndex, Math.Min(8, binaryString_green.Length - startIndex));
                binaryData_green[i] = Convert.ToByte(byteString, 2);
            }

            finalData_green = binaryData_green;

            ////////////////////////////////////////////////
            ///

            int numBytes_blue = (binaryString_blue.Length + 7) / 8;
            byte[] binaryData_blue = new byte[numBytes_blue];
            for (int i = 0; i < numBytes_blue; i++)
            {
                int startIndex = Math.Max(0, binaryString_blue.Length - (i + 1) * 8);
                string byteString = binaryString_blue.Substring(startIndex, Math.Min(8, binaryString_blue.Length - startIndex));
                binaryData_blue[i] = Convert.ToByte(byteString, 2);
            }

            finalData_blue = binaryData_blue;
        }

        void save(BinaryConvert myObject)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream("C:\\Users\\mero1\\Desktop\\Exam\\_114\\my_output\\myObject.bin", FileMode.Create))
            {
                formatter.Serialize(stream, myObject);
            }
        }

        void save_encode(BinaryConvertForEncode myObject)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream("C:\\Users\\mero1\\Desktop\\Exam\\_114\\my_output\\myEncodedImage.bin", FileMode.Create))
            {
                formatter.Serialize(stream, myObject);
            }
        }


    }

    //6

    internal class ExtractFiles
    {
        BinaryConvert myObject;
        public BinaryConvertForEncode myObjectEncode;
        public Huff huff;
        public string seed;
        public int tap;
        public ExtractFiles()
        {
            myObject = extractObject();
            huff = new Huff();
            seed = myObject.seed;
            tap = myObject.tap;
            // set the original huffman value
            huff.final_encoded_red = RemovelastXCharacters(ByteToBinary22(myObject.red), myObject.remain_red);
            huff.final_encoded_green = RemovelastXCharacters(ByteToBinary22(myObject.green), myObject.remain_green);
            huff.final_encoded_blue = RemovelastXCharacters(ByteToBinary22(myObject.blue), myObject.remain_blue);

            huff.freq_red = myObject.freq_red;
            huff.freq_green = myObject.freq_green;
            huff.freq_blue = myObject.freq_blue;

            huff.row = myObject.row;
            huff.column = myObject.column;

            //generate the huffman tree
            huff.deserializeSteps();

        }

        public ExtractFiles(bool encode_only) 
        {
            myObjectEncode = extractObjectEncode();
        }

        BinaryConvert extractObject()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            
            using (FileStream stream = new FileStream("C:\\Users\\mero1\\Desktop\\Exam\\_114\\my_output\\myObject.bin", FileMode.Open))
            {
                BinaryConvert deserializedObject = (BinaryConvert)formatter.Deserialize(stream);
                
                return deserializedObject;
            }
        }

        BinaryConvertForEncode extractObjectEncode()
        {

            BinaryFormatter formatter = new BinaryFormatter();
            
            using (FileStream stream = new FileStream("C:\\Users\\mero1\\Desktop\\Exam\\_114\\my_output\\myEncodedImage.bin", FileMode.Open))
            {
                BinaryConvertForEncode deserializedObject = (BinaryConvertForEncode)formatter.Deserialize(stream);
                
                return deserializedObject;
            }
        }

  
        string ByteToBinary22(byte[] value)
        {
            StringBuilder binary = new StringBuilder(value.Length * 8);
            for (int i = value.Length - 1; i >= 0; i--)
            {
                byte currentByte = value[i];
                for (int j = 7; j >= 0; j--)
                {
                    binary.Append((currentByte & (1 << j)) != 0 ? '1' : '0');
                }
            }
            return binary.ToString();
        }


        string RemovelastXCharacters(string input, int x)
        {
            if (x != 8)
            {
                if (x >= input.Length)
                    return string.Empty; // Return an empty string if x is greater than or equal to the input length
                else
                    return input.Substring(0, input.Length - x);
            }
            else
            {

                return input;
            }


        }

    }

    //7
    public class MinPriorityQueue<TKey, TValue>
    {
        private readonly SortedDictionary<TKey, Queue<TValue>> _queue = new();
        private readonly IComparer<TKey> _keyComparer;

        public MinPriorityQueue(IComparer<TKey> keyComparer = null)
        {
            _keyComparer = keyComparer ?? Comparer<TKey>.Default;
        }

        // Enqueue an element with priority
        public void Enqueue(TKey priority, TValue value)
        {
            if (!_queue.ContainsKey(priority))
            {
                _queue[priority] = new Queue<TValue>();
            }
            _queue[priority].Enqueue(value);
        }

        // Dequeue element with highest priority
        public TValue Dequeue()
        {
            if (_queue.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            var minPriority = _queue.Keys.Min(); // Get the minimum key (lowest priority)
            var dequeuedValue = _queue[minPriority].Dequeue();

            // Remove the key if the queue is empty for that priority
            if (_queue[minPriority].Count == 0)
            {
                _queue.Remove(minPriority);
            }

            return dequeuedValue;
        }

        // View the element with lowest priority without dequeuing
        public TValue Peek()
        {
            if (_queue.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            var minPriority = _queue.Keys.Min(); // Get the minimum key (lowest priority)
            return _queue[minPriority].Peek();
        }

        public int Size()
        {
            return _queue.Values.Sum(queue => queue.Count);
        }

    }
}

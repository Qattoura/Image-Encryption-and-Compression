namespace ImageEncryptCompress
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Encode_Button = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Seed_Box = new System.Windows.Forms.TextBox();
            this.Tap_Box = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.decode_btn = new System.Windows.Forms.Button();
            this.decode_image_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnGaussSmooth = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudMaskSize = new System.Windows.Forms.NumericUpDown();
            this.txtGaussSigma = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaskSize)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(427, 360);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(412, 360);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(355, 417);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(95, 72);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open Image";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 393);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Original Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(605, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Smoothed Image";
            // 
            // txtHeight
            // 
            this.txtHeight.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeight.Location = new System.Drawing.Point(281, 467);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ReadOnly = true;
            this.txtHeight.Size = new System.Drawing.Size(57, 23);
            this.txtHeight.TabIndex = 8;
            // 
            // txtWidth
            // 
            this.txtWidth.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWidth.Location = new System.Drawing.Point(281, 428);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ReadOnly = true;
            this.txtWidth.Size = new System.Drawing.Size(57, 23);
            this.txtWidth.TabIndex = 11;
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(226, 430);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(226, 469);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Height";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 371);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(471, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(421, 371);
            this.panel2.TabIndex = 16;
            // 
            // Encode_Button
            // 
            this.Encode_Button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Encode_Button.Location = new System.Drawing.Point(342, 524);
            this.Encode_Button.Name = "Encode_Button";
            this.Encode_Button.Size = new System.Drawing.Size(227, 40);
            this.Encode_Button.TabIndex = 17;
            this.Encode_Button.Text = "Encode";
            this.Encode_Button.UseVisualStyleBackColor = true;
            this.Encode_Button.Click += new System.EventHandler(this.Encode_Button_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(591, 535);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "tap";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(591, 592);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Seed";
            // 
            // Seed_Box
            // 
            this.Seed_Box.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Seed_Box.Location = new System.Drawing.Point(696, 587);
            this.Seed_Box.Name = "Seed_Box";
            this.Seed_Box.Size = new System.Drawing.Size(57, 23);
            this.Seed_Box.TabIndex = 20;
            this.Seed_Box.Text = "1";
            this.Seed_Box.TextChanged += new System.EventHandler(this.Seed_Box_TextChanged);
            // 
            // Tap_Box
            // 
            this.Tap_Box.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tap_Box.Location = new System.Drawing.Point(696, 535);
            this.Tap_Box.Name = "Tap_Box";
            this.Tap_Box.Size = new System.Drawing.Size(57, 23);
            this.Tap_Box.TabIndex = 21;
            this.Tap_Box.Text = "1";
            this.Tap_Box.TextChanged += new System.EventHandler(this.Tap_Box_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(366, 619);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 32);
            this.label9.TabIndex = 22;
            this.label9.Text = "Max password size is 4 \r\n\r\n";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // decode_btn
            // 
            this.decode_btn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decode_btn.Location = new System.Drawing.Point(794, 393);
            this.decode_btn.Name = "decode_btn";
            this.decode_btn.Size = new System.Drawing.Size(98, 72);
            this.decode_btn.TabIndex = 23;
            this.decode_btn.Text = "open decoded image";
            this.decode_btn.UseVisualStyleBackColor = true;
            this.decode_btn.Click += new System.EventHandler(this.decode_btn_Click);
            // 
            // decode_image_btn
            // 
            this.decode_image_btn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decode_image_btn.Location = new System.Drawing.Point(794, 483);
            this.decode_image_btn.Name = "decode_image_btn";
            this.decode_image_btn.Size = new System.Drawing.Size(98, 72);
            this.decode_image_btn.TabIndex = 24;
            this.decode_image_btn.Text = "Decode";
            this.decode_image_btn.UseVisualStyleBackColor = true;
            this.decode_image_btn.Click += new System.EventHandler(this.decode_image_btn_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(342, 570);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 46);
            this.button1.TabIndex = 25;
            this.button1.Text = "alphanumeric encode";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(794, 561);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 72);
            this.button2.TabIndex = 26;
            this.button2.Text = "alpha DE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(1030, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(169, 275);
            this.button3.TabIndex = 27;
            this.button3.Text = "compress";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(1030, 308);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(169, 290);
            this.button4.TabIndex = 28;
            this.button4.Text = "decomprss";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(975, 612);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 16);
            this.label10.TabIndex = 30;
            this.label10.Text = "Ratio";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(1030, 610);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(169, 23);
            this.textBox1.TabIndex = 29;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // btnGaussSmooth
            // 
            this.btnGaussSmooth.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGaussSmooth.Location = new System.Drawing.Point(471, 417);
            this.btnGaussSmooth.Name = "btnGaussSmooth";
            this.btnGaussSmooth.Size = new System.Drawing.Size(98, 72);
            this.btnGaussSmooth.TabIndex = 5;
            this.btnGaussSmooth.Text = "Apply Operation (Example)";
            this.btnGaussSmooth.UseVisualStyleBackColor = true;
            this.btnGaussSmooth.Click += new System.EventHandler(this.btnGaussSmooth_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(591, 430);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mask Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(591, 469);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Gauss Sigma";
            // 
            // nudMaskSize
            // 
            this.nudMaskSize.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMaskSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudMaskSize.Location = new System.Drawing.Point(685, 428);
            this.nudMaskSize.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudMaskSize.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudMaskSize.Name = "nudMaskSize";
            this.nudMaskSize.Size = new System.Drawing.Size(57, 23);
            this.nudMaskSize.TabIndex = 10;
            this.nudMaskSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // txtGaussSigma
            // 
            this.txtGaussSigma.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGaussSigma.Location = new System.Drawing.Point(685, 467);
            this.txtGaussSigma.Name = "txtGaussSigma";
            this.txtGaussSigma.Size = new System.Drawing.Size(57, 23);
            this.txtGaussSigma.TabIndex = 14;
            this.txtGaussSigma.Text = "1";
            this.txtGaussSigma.TextChanged += new System.EventHandler(this.txtGaussSigma_TextChanged);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(342, 639);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(319, 54);
            this.button5.TabIndex = 31;
            this.button5.Text = "Encode and compress";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(667, 639);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(319, 54);
            this.button6.TabIndex = 32;
            this.button6.Text = "Decompress and Decode";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(342, 708);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(319, 54);
            this.button7.TabIndex = 33;
            this.button7.Text = "Encode and compress";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(667, 708);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(319, 54);
            this.button8.TabIndex = 34;
            this.button8.Text = "Decompress and encode";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(183, 660);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 16);
            this.label11.TabIndex = 35;
            this.label11.Text = "binary seed encoding";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(183, 729);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(131, 16);
            this.label12.TabIndex = 36;
            this.label12.Text = "alpa seed encoding";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(1039, 670);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(169, 23);
            this.textBox2.TabIndex = 37;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(992, 677);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 16);
            this.label13.TabIndex = 38;
            this.label13.Text = "Time";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 764);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.decode_image_btn);
            this.Controls.Add(this.decode_btn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Tap_Box);
            this.Controls.Add(this.Seed_Box);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Encode_Button);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtGaussSigma);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.nudMaskSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGaussSmooth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpen);
            this.Name = "MainForm";
            this.Text = "Image Enctryption and Compression...";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaskSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Encode_Button;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Seed_Box;
        private System.Windows.Forms.TextBox Tap_Box;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button decode_btn;
        private System.Windows.Forms.Button decode_image_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnGaussSmooth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudMaskSize;
        private System.Windows.Forms.TextBox txtGaussSigma;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label13;
    }
}


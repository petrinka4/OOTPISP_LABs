namespace Lab1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox = new PictureBox();
            drawButton = new Button();
            clearButton = new Button();
            buttonLine = new Button();
            buttonRectangle = new Button();
            buttonEllipse = new Button();
            buttonPolygon = new Button();
            buttonBrLine = new Button();
            colorDialog1 = new ColorDialog();
            buttonColorLine = new Button();
            buttonColorBack = new Button();
            trackBarWidth = new TrackBar();
            buttonCtrlZ = new Button();
            buttonCtrlY = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarWidth).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.None;
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Location = new Point(0, 70);
            pictureBox.Margin = new Padding(2);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(972, 385);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.Paint += pictureBox_Paint;
            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseMove += pictureBox_MouseMove;
            pictureBox.MouseUp += pictureBox_MouseUp;
            // 
            // drawButton
            // 
            drawButton.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            drawButton.Location = new Point(145, 459);
            drawButton.Margin = new Padding(2);
            drawButton.Name = "drawButton";
            drawButton.Size = new Size(151, 57);
            drawButton.TabIndex = 1;
            drawButton.Text = "Print";
            drawButton.UseVisualStyleBackColor = true;
            drawButton.Click += drawButton_Click;
            // 
            // clearButton
            // 
            clearButton.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            clearButton.Location = new Point(689, 459);
            clearButton.Margin = new Padding(2);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(150, 57);
            clearButton.TabIndex = 2;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // buttonLine
            // 
            buttonLine.Location = new Point(12, 12);
            buttonLine.Name = "buttonLine";
            buttonLine.Size = new Size(94, 29);
            buttonLine.TabIndex = 4;
            buttonLine.Text = "LINE";
            buttonLine.UseVisualStyleBackColor = true;
            buttonLine.Click += buttonLine_Click;
            // 
            // buttonRectangle
            // 
            buttonRectangle.Location = new Point(112, 36);
            buttonRectangle.Name = "buttonRectangle";
            buttonRectangle.Size = new Size(111, 29);
            buttonRectangle.TabIndex = 5;
            buttonRectangle.Text = "RECTANGLE";
            buttonRectangle.UseVisualStyleBackColor = true;
            buttonRectangle.Click += buttonRectangle_Click;
            // 
            // buttonEllipse
            // 
            buttonEllipse.Location = new Point(229, 12);
            buttonEllipse.Name = "buttonEllipse";
            buttonEllipse.Size = new Size(94, 29);
            buttonEllipse.TabIndex = 6;
            buttonEllipse.Text = "ELLIPSE";
            buttonEllipse.UseVisualStyleBackColor = true;
            buttonEllipse.Click += buttonEllipse_Click;
            // 
            // buttonPolygon
            // 
            buttonPolygon.Location = new Point(329, 36);
            buttonPolygon.Name = "buttonPolygon";
            buttonPolygon.Size = new Size(94, 29);
            buttonPolygon.TabIndex = 7;
            buttonPolygon.Text = "POLYGON";
            buttonPolygon.UseVisualStyleBackColor = true;
            buttonPolygon.Click += buttonPolygon_Click;
            // 
            // buttonBrLine
            // 
            buttonBrLine.Location = new Point(429, 12);
            buttonBrLine.Name = "buttonBrLine";
            buttonBrLine.Size = new Size(94, 29);
            buttonBrLine.TabIndex = 8;
            buttonBrLine.Text = "BR LINE";
            buttonBrLine.UseVisualStyleBackColor = true;
            buttonBrLine.Click += buttonBrLine_Click;
            // 
            // colorDialog1
            // 
            colorDialog1.Color = Color.White;
            // 
            // buttonColorLine
            // 
            buttonColorLine.Location = new Point(671, 12);
            buttonColorLine.Name = "buttonColorLine";
            buttonColorLine.Size = new Size(37, 37);
            buttonColorLine.TabIndex = 9;
            buttonColorLine.UseVisualStyleBackColor = true;
            buttonColorLine.Click += buttonColor_Click;
            // 
            // buttonColorBack
            // 
            buttonColorBack.Location = new Point(714, 12);
            buttonColorBack.Name = "buttonColorBack";
            buttonColorBack.Size = new Size(37, 37);
            buttonColorBack.TabIndex = 10;
            buttonColorBack.UseVisualStyleBackColor = true;
            buttonColorBack.Click += buttonColorBack_Click;
            // 
            // trackBarWidth
            // 
            trackBarWidth.Location = new Point(757, 9);
            trackBarWidth.Maximum = 100;
            trackBarWidth.Name = "trackBarWidth";
            trackBarWidth.Size = new Size(130, 56);
            trackBarWidth.TabIndex = 11;
            trackBarWidth.Scroll += trackBarWidth_Scroll;
            // 
            // buttonCtrlZ
            // 
            buttonCtrlZ.Location = new Point(893, 36);
            buttonCtrlZ.Name = "buttonCtrlZ";
            buttonCtrlZ.Size = new Size(34, 29);
            buttonCtrlZ.TabIndex = 12;
            buttonCtrlZ.Text = "<-";
            buttonCtrlZ.UseVisualStyleBackColor = true;
            buttonCtrlZ.Click += buttonCtrlZ_Click;
            // 
            // buttonCtrlY
            // 
            buttonCtrlY.Location = new Point(933, 36);
            buttonCtrlY.Name = "buttonCtrlY";
            buttonCtrlY.Size = new Size(34, 29);
            buttonCtrlY.TabIndex = 13;
            buttonCtrlY.Text = "->";
            buttonCtrlY.UseVisualStyleBackColor = true;
            buttonCtrlY.Click += buttonCtrlY_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(972, 543);
            Controls.Add(buttonCtrlY);
            Controls.Add(buttonCtrlZ);
            Controls.Add(trackBarWidth);
            Controls.Add(buttonColorBack);
            Controls.Add(buttonColorLine);
            Controls.Add(buttonBrLine);
            Controls.Add(buttonPolygon);
            Controls.Add(buttonEllipse);
            Controls.Add(buttonRectangle);
            Controls.Add(buttonLine);
            Controls.Add(clearButton);
            Controls.Add(drawButton);
            Controls.Add(pictureBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(2);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarWidth).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Button drawButton;
        private Button clearButton;
        private Button buttonLine;
        private Button buttonRectangle;
        private Button buttonEllipse;
        private Button buttonPolygon;
        private Button buttonBrLine;
        private ColorDialog colorDialog1;
        private Button buttonColorLine;
        private Button buttonColorBack;
        private TrackBar trackBarWidth;
        private Button buttonCtrlZ;
        private Button buttonCtrlY;
    }
}

namespace Illuminated_sphere;

partial class form_mainWindow
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
			this.tableLayoutPanel_main = new System.Windows.Forms.TableLayoutPanel();
			this.pictureBox_workingArea = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel_right = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox_buttons = new System.Windows.Forms.GroupBox();
			this.button_clear = new System.Windows.Forms.Button();
			this.button_redraw = new System.Windows.Forms.Button();
			this.button_onePolygon = new System.Windows.Forms.Button();
			this.button_outline = new System.Windows.Forms.Button();
			this.groupBox_parameters = new System.Windows.Forms.GroupBox();
			this.radioButton_normalInterpolation = new System.Windows.Forms.RadioButton();
			this.radioButton_colorInterpolation = new System.Windows.Forms.RadioButton();
			this.label_mValue = new System.Windows.Forms.Label();
			this.label_ksValue = new System.Windows.Forms.Label();
			this.trackBar_m = new System.Windows.Forms.TrackBar();
			this.label_m = new System.Windows.Forms.Label();
			this.trackBar_ks = new System.Windows.Forms.TrackBar();
			this.label_ks = new System.Windows.Forms.Label();
			this.label_kdValue = new System.Windows.Forms.Label();
			this.label_kd = new System.Windows.Forms.Label();
			this.trackBar_kd = new System.Windows.Forms.TrackBar();
			this.groupBox_sun = new System.Windows.Forms.GroupBox();
			this.panel_sunColor = new System.Windows.Forms.Panel();
			this.label_sunHeightValue = new System.Windows.Forms.Label();
			this.trackBar_sunHeight = new System.Windows.Forms.TrackBar();
			this.checkBox_sunAnimation = new System.Windows.Forms.CheckBox();
			this.label_sunHeight = new System.Windows.Forms.Label();
			this.label_sunColor = new System.Windows.Forms.Label();
			this.groupBox_object = new System.Windows.Forms.GroupBox();
			this.button_texture = new System.Windows.Forms.Button();
			this.radioButton_texture = new System.Windows.Forms.RadioButton();
			this.radioButton_color = new System.Windows.Forms.RadioButton();
			this.panel_objColor = new System.Windows.Forms.Panel();
			this.groupBox_normalMap = new System.Windows.Forms.GroupBox();
			this.label_normalMapFile = new System.Windows.Forms.Label();
			this.button_clearNormalMap = new System.Windows.Forms.Button();
			this.button_loadNormalMap = new System.Windows.Forms.Button();
			this.tableLayoutPanel_main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_workingArea)).BeginInit();
			this.tableLayoutPanel_right.SuspendLayout();
			this.groupBox_buttons.SuspendLayout();
			this.groupBox_parameters.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_m)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_ks)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_kd)).BeginInit();
			this.groupBox_sun.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_sunHeight)).BeginInit();
			this.groupBox_object.SuspendLayout();
			this.groupBox_normalMap.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel_main
			// 
			this.tableLayoutPanel_main.ColumnCount = 2;
			this.tableLayoutPanel_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
			this.tableLayoutPanel_main.Controls.Add(this.pictureBox_workingArea, 0, 0);
			this.tableLayoutPanel_main.Controls.Add(this.tableLayoutPanel_right, 1, 0);
			this.tableLayoutPanel_main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_main.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel_main.Name = "tableLayoutPanel_main";
			this.tableLayoutPanel_main.RowCount = 1;
			this.tableLayoutPanel_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_main.Size = new System.Drawing.Size(984, 761);
			this.tableLayoutPanel_main.TabIndex = 0;
			// 
			// pictureBox_workingArea
			// 
			this.pictureBox_workingArea.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox_workingArea.Location = new System.Drawing.Point(3, 3);
			this.pictureBox_workingArea.Name = "pictureBox_workingArea";
			this.pictureBox_workingArea.Size = new System.Drawing.Size(778, 755);
			this.pictureBox_workingArea.TabIndex = 0;
			this.pictureBox_workingArea.TabStop = false;
			// 
			// tableLayoutPanel_right
			// 
			this.tableLayoutPanel_right.ColumnCount = 1;
			this.tableLayoutPanel_right.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel_right.Controls.Add(this.groupBox_buttons, 0, 0);
			this.tableLayoutPanel_right.Controls.Add(this.groupBox_parameters, 0, 1);
			this.tableLayoutPanel_right.Controls.Add(this.groupBox_sun, 0, 2);
			this.tableLayoutPanel_right.Controls.Add(this.groupBox_object, 0, 3);
			this.tableLayoutPanel_right.Controls.Add(this.groupBox_normalMap, 0, 4);
			this.tableLayoutPanel_right.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_right.Location = new System.Drawing.Point(787, 3);
			this.tableLayoutPanel_right.Name = "tableLayoutPanel_right";
			this.tableLayoutPanel_right.RowCount = 5;
			this.tableLayoutPanel_right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.00901F));
			this.tableLayoutPanel_right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.213F));
			this.tableLayoutPanel_right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.78368F));
			this.tableLayoutPanel_right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.99431F));
			this.tableLayoutPanel_right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 107F));
			this.tableLayoutPanel_right.Size = new System.Drawing.Size(194, 755);
			this.tableLayoutPanel_right.TabIndex = 3;
			// 
			// groupBox_buttons
			// 
			this.groupBox_buttons.Controls.Add(this.button_clear);
			this.groupBox_buttons.Controls.Add(this.button_redraw);
			this.groupBox_buttons.Controls.Add(this.button_onePolygon);
			this.groupBox_buttons.Controls.Add(this.button_outline);
			this.groupBox_buttons.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox_buttons.Location = new System.Drawing.Point(3, 3);
			this.groupBox_buttons.Name = "groupBox_buttons";
			this.groupBox_buttons.Size = new System.Drawing.Size(188, 104);
			this.groupBox_buttons.TabIndex = 0;
			this.groupBox_buttons.TabStop = false;
			this.groupBox_buttons.Text = "Buttons";
			// 
			// button_clear
			// 
			this.button_clear.Location = new System.Drawing.Point(106, 65);
			this.button_clear.Name = "button_clear";
			this.button_clear.Size = new System.Drawing.Size(75, 23);
			this.button_clear.TabIndex = 3;
			this.button_clear.Text = "Clear";
			this.button_clear.UseVisualStyleBackColor = true;
			// 
			// button_redraw
			// 
			this.button_redraw.Location = new System.Drawing.Point(106, 22);
			this.button_redraw.Name = "button_redraw";
			this.button_redraw.Size = new System.Drawing.Size(75, 23);
			this.button_redraw.TabIndex = 2;
			this.button_redraw.Text = "Redraw";
			this.button_redraw.UseVisualStyleBackColor = true;
			this.button_redraw.Click += new System.EventHandler(this.button_redraw_Click);
			// 
			// button_onePolygon
			// 
			this.button_onePolygon.Location = new System.Drawing.Point(6, 65);
			this.button_onePolygon.Name = "button_onePolygon";
			this.button_onePolygon.Size = new System.Drawing.Size(75, 23);
			this.button_onePolygon.TabIndex = 1;
			this.button_onePolygon.Text = "One poly";
			this.button_onePolygon.UseVisualStyleBackColor = true;
			this.button_onePolygon.Click += new System.EventHandler(this.button_onePolygon_Click);
			// 
			// button_outline
			// 
			this.button_outline.Location = new System.Drawing.Point(6, 22);
			this.button_outline.Name = "button_outline";
			this.button_outline.Size = new System.Drawing.Size(75, 23);
			this.button_outline.TabIndex = 0;
			this.button_outline.Text = "Outline";
			this.button_outline.UseVisualStyleBackColor = true;
			this.button_outline.Click += new System.EventHandler(this.button_outline_Click);
			// 
			// groupBox_parameters
			// 
			this.groupBox_parameters.Controls.Add(this.radioButton_normalInterpolation);
			this.groupBox_parameters.Controls.Add(this.radioButton_colorInterpolation);
			this.groupBox_parameters.Controls.Add(this.label_mValue);
			this.groupBox_parameters.Controls.Add(this.label_ksValue);
			this.groupBox_parameters.Controls.Add(this.trackBar_m);
			this.groupBox_parameters.Controls.Add(this.label_m);
			this.groupBox_parameters.Controls.Add(this.trackBar_ks);
			this.groupBox_parameters.Controls.Add(this.label_ks);
			this.groupBox_parameters.Controls.Add(this.label_kdValue);
			this.groupBox_parameters.Controls.Add(this.label_kd);
			this.groupBox_parameters.Controls.Add(this.trackBar_kd);
			this.groupBox_parameters.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox_parameters.Location = new System.Drawing.Point(3, 113);
			this.groupBox_parameters.Name = "groupBox_parameters";
			this.groupBox_parameters.Size = new System.Drawing.Size(188, 222);
			this.groupBox_parameters.TabIndex = 1;
			this.groupBox_parameters.TabStop = false;
			this.groupBox_parameters.Text = "Parameters";
			// 
			// radioButton_normalInterpolation
			// 
			this.radioButton_normalInterpolation.AutoSize = true;
			this.radioButton_normalInterpolation.Location = new System.Drawing.Point(6, 193);
			this.radioButton_normalInterpolation.Name = "radioButton_normalInterpolation";
			this.radioButton_normalInterpolation.Size = new System.Drawing.Size(175, 19);
			this.radioButton_normalInterpolation.TabIndex = 10;
			this.radioButton_normalInterpolation.Text = "Normal vector inperpolation";
			this.radioButton_normalInterpolation.UseVisualStyleBackColor = true;
			// 
			// radioButton_colorInterpolation
			// 
			this.radioButton_colorInterpolation.AutoSize = true;
			this.radioButton_colorInterpolation.Checked = true;
			this.radioButton_colorInterpolation.Location = new System.Drawing.Point(6, 168);
			this.radioButton_colorInterpolation.Name = "radioButton_colorInterpolation";
			this.radioButton_colorInterpolation.Size = new System.Drawing.Size(125, 19);
			this.radioButton_colorInterpolation.TabIndex = 9;
			this.radioButton_colorInterpolation.TabStop = true;
			this.radioButton_colorInterpolation.Text = "Color interpolation";
			this.radioButton_colorInterpolation.UseVisualStyleBackColor = true;
			this.radioButton_colorInterpolation.CheckedChanged += new System.EventHandler(this.radioButton_colorInterpolation_CheckedChanged);
			// 
			// label_mValue
			// 
			this.label_mValue.AutoSize = true;
			this.label_mValue.Location = new System.Drawing.Point(153, 115);
			this.label_mValue.Name = "label_mValue";
			this.label_mValue.Size = new System.Drawing.Size(19, 15);
			this.label_mValue.TabIndex = 8;
			this.label_mValue.Text = "20";
			// 
			// label_ksValue
			// 
			this.label_ksValue.AutoSize = true;
			this.label_ksValue.Location = new System.Drawing.Point(153, 67);
			this.label_ksValue.Name = "label_ksValue";
			this.label_ksValue.Size = new System.Drawing.Size(28, 15);
			this.label_ksValue.TabIndex = 7;
			this.label_ksValue.Text = "0,50";
			// 
			// trackBar_m
			// 
			this.trackBar_m.LargeChange = 10;
			this.trackBar_m.Location = new System.Drawing.Point(6, 131);
			this.trackBar_m.Maximum = 100;
			this.trackBar_m.Minimum = 1;
			this.trackBar_m.Name = "trackBar_m";
			this.trackBar_m.Size = new System.Drawing.Size(176, 45);
			this.trackBar_m.TabIndex = 6;
			this.trackBar_m.Tag = "";
			this.trackBar_m.TickFrequency = 20;
			this.trackBar_m.Value = 20;
			this.trackBar_m.Scroll += new System.EventHandler(this.trackBar_m_Scroll);
			// 
			// label_m
			// 
			this.label_m.AutoSize = true;
			this.label_m.Location = new System.Drawing.Point(6, 115);
			this.label_m.Name = "label_m";
			this.label_m.Size = new System.Drawing.Size(18, 15);
			this.label_m.TabIndex = 5;
			this.label_m.Text = "m";
			// 
			// trackBar_ks
			// 
			this.trackBar_ks.LargeChange = 10;
			this.trackBar_ks.Location = new System.Drawing.Point(6, 85);
			this.trackBar_ks.Maximum = 100;
			this.trackBar_ks.Name = "trackBar_ks";
			this.trackBar_ks.Size = new System.Drawing.Size(176, 45);
			this.trackBar_ks.TabIndex = 4;
			this.trackBar_ks.Tag = "";
			this.trackBar_ks.TickFrequency = 20;
			this.trackBar_ks.Value = 50;
			this.trackBar_ks.Scroll += new System.EventHandler(this.trackBar_ks_Scroll);
			// 
			// label_ks
			// 
			this.label_ks.AutoSize = true;
			this.label_ks.Location = new System.Drawing.Point(6, 67);
			this.label_ks.Name = "label_ks";
			this.label_ks.Size = new System.Drawing.Size(18, 15);
			this.label_ks.TabIndex = 3;
			this.label_ks.Text = "ks";
			// 
			// label_kdValue
			// 
			this.label_kdValue.AutoSize = true;
			this.label_kdValue.Location = new System.Drawing.Point(153, 19);
			this.label_kdValue.Name = "label_kdValue";
			this.label_kdValue.Size = new System.Drawing.Size(28, 15);
			this.label_kdValue.TabIndex = 2;
			this.label_kdValue.Text = "1,00";
			// 
			// label_kd
			// 
			this.label_kd.AutoSize = true;
			this.label_kd.Location = new System.Drawing.Point(6, 19);
			this.label_kd.Name = "label_kd";
			this.label_kd.Size = new System.Drawing.Size(20, 15);
			this.label_kd.TabIndex = 1;
			this.label_kd.Text = "kd";
			// 
			// trackBar_kd
			// 
			this.trackBar_kd.LargeChange = 10;
			this.trackBar_kd.Location = new System.Drawing.Point(6, 37);
			this.trackBar_kd.Maximum = 100;
			this.trackBar_kd.Name = "trackBar_kd";
			this.trackBar_kd.Size = new System.Drawing.Size(176, 45);
			this.trackBar_kd.TabIndex = 0;
			this.trackBar_kd.Tag = "";
			this.trackBar_kd.TickFrequency = 20;
			this.trackBar_kd.Value = 100;
			this.trackBar_kd.Scroll += new System.EventHandler(this.trackBar_kd_Scroll);
			// 
			// groupBox_sun
			// 
			this.groupBox_sun.Controls.Add(this.panel_sunColor);
			this.groupBox_sun.Controls.Add(this.label_sunHeightValue);
			this.groupBox_sun.Controls.Add(this.trackBar_sunHeight);
			this.groupBox_sun.Controls.Add(this.checkBox_sunAnimation);
			this.groupBox_sun.Controls.Add(this.label_sunHeight);
			this.groupBox_sun.Controls.Add(this.label_sunColor);
			this.groupBox_sun.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox_sun.Location = new System.Drawing.Point(3, 341);
			this.groupBox_sun.Name = "groupBox_sun";
			this.groupBox_sun.Size = new System.Drawing.Size(188, 186);
			this.groupBox_sun.TabIndex = 2;
			this.groupBox_sun.TabStop = false;
			this.groupBox_sun.Text = "Sun";
			// 
			// panel_sunColor
			// 
			this.panel_sunColor.BackColor = System.Drawing.Color.Red;
			this.panel_sunColor.Location = new System.Drawing.Point(106, 22);
			this.panel_sunColor.Name = "panel_sunColor";
			this.panel_sunColor.Size = new System.Drawing.Size(75, 30);
			this.panel_sunColor.TabIndex = 10;
			this.panel_sunColor.Click += new System.EventHandler(this.panel_sunColor_Click);
			// 
			// label_sunHeightValue
			// 
			this.label_sunHeightValue.AutoSize = true;
			this.label_sunHeightValue.Location = new System.Drawing.Point(153, 62);
			this.label_sunHeightValue.Name = "label_sunHeightValue";
			this.label_sunHeightValue.Size = new System.Drawing.Size(13, 15);
			this.label_sunHeightValue.TabIndex = 9;
			this.label_sunHeightValue.Text = "1";
			// 
			// trackBar_sunHeight
			// 
			this.trackBar_sunHeight.LargeChange = 10;
			this.trackBar_sunHeight.Location = new System.Drawing.Point(6, 92);
			this.trackBar_sunHeight.Maximum = 50;
			this.trackBar_sunHeight.Minimum = 10;
			this.trackBar_sunHeight.Name = "trackBar_sunHeight";
			this.trackBar_sunHeight.Size = new System.Drawing.Size(176, 45);
			this.trackBar_sunHeight.TabIndex = 7;
			this.trackBar_sunHeight.Tag = "";
			this.trackBar_sunHeight.TickFrequency = 10;
			this.trackBar_sunHeight.Value = 10;
			this.trackBar_sunHeight.Scroll += new System.EventHandler(this.trackBar_sunHeight_Scroll);
			// 
			// checkBox_sunAnimation
			// 
			this.checkBox_sunAnimation.AutoSize = true;
			this.checkBox_sunAnimation.Location = new System.Drawing.Point(6, 143);
			this.checkBox_sunAnimation.Name = "checkBox_sunAnimation";
			this.checkBox_sunAnimation.Size = new System.Drawing.Size(82, 19);
			this.checkBox_sunAnimation.TabIndex = 3;
			this.checkBox_sunAnimation.Text = "Animation";
			this.checkBox_sunAnimation.UseVisualStyleBackColor = true;
			this.checkBox_sunAnimation.CheckedChanged += new System.EventHandler(this.checkBox_sunAnimation_CheckedChanged);
			// 
			// label_sunHeight
			// 
			this.label_sunHeight.AutoSize = true;
			this.label_sunHeight.Location = new System.Drawing.Point(6, 62);
			this.label_sunHeight.Name = "label_sunHeight";
			this.label_sunHeight.Size = new System.Drawing.Size(43, 15);
			this.label_sunHeight.TabIndex = 1;
			this.label_sunHeight.Text = "Height";
			// 
			// label_sunColor
			// 
			this.label_sunColor.AutoSize = true;
			this.label_sunColor.Location = new System.Drawing.Point(6, 29);
			this.label_sunColor.Name = "label_sunColor";
			this.label_sunColor.Size = new System.Drawing.Size(36, 15);
			this.label_sunColor.TabIndex = 0;
			this.label_sunColor.Text = "Color";
			// 
			// groupBox_object
			// 
			this.groupBox_object.Controls.Add(this.button_texture);
			this.groupBox_object.Controls.Add(this.radioButton_texture);
			this.groupBox_object.Controls.Add(this.radioButton_color);
			this.groupBox_object.Controls.Add(this.panel_objColor);
			this.groupBox_object.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox_object.Location = new System.Drawing.Point(3, 533);
			this.groupBox_object.Name = "groupBox_object";
			this.groupBox_object.Size = new System.Drawing.Size(188, 110);
			this.groupBox_object.TabIndex = 3;
			this.groupBox_object.TabStop = false;
			this.groupBox_object.Text = "Object";
			// 
			// button_texture
			// 
			this.button_texture.Location = new System.Drawing.Point(106, 72);
			this.button_texture.Name = "button_texture";
			this.button_texture.Size = new System.Drawing.Size(75, 23);
			this.button_texture.TabIndex = 14;
			this.button_texture.Text = "Load";
			this.button_texture.UseVisualStyleBackColor = true;
			this.button_texture.Click += new System.EventHandler(this.button_texture_Click);
			// 
			// radioButton_texture
			// 
			this.radioButton_texture.AutoSize = true;
			this.radioButton_texture.Checked = true;
			this.radioButton_texture.Location = new System.Drawing.Point(6, 72);
			this.radioButton_texture.Name = "radioButton_texture";
			this.radioButton_texture.Size = new System.Drawing.Size(63, 19);
			this.radioButton_texture.TabIndex = 13;
			this.radioButton_texture.TabStop = true;
			this.radioButton_texture.Text = "Texture";
			this.radioButton_texture.UseVisualStyleBackColor = true;
			this.radioButton_texture.CheckedChanged += new System.EventHandler(this.radioButton_texture_CheckedChanged);
			// 
			// radioButton_color
			// 
			this.radioButton_color.AutoSize = true;
			this.radioButton_color.Location = new System.Drawing.Point(6, 27);
			this.radioButton_color.Name = "radioButton_color";
			this.radioButton_color.Size = new System.Drawing.Size(54, 19);
			this.radioButton_color.TabIndex = 12;
			this.radioButton_color.Text = "Color";
			this.radioButton_color.UseVisualStyleBackColor = true;
			// 
			// panel_objColor
			// 
			this.panel_objColor.BackColor = System.Drawing.Color.Red;
			this.panel_objColor.Location = new System.Drawing.Point(106, 22);
			this.panel_objColor.Name = "panel_objColor";
			this.panel_objColor.Size = new System.Drawing.Size(75, 30);
			this.panel_objColor.TabIndex = 11;
			this.panel_objColor.Click += new System.EventHandler(this.panel_objColor_Click);
			// 
			// groupBox_normalMap
			// 
			this.groupBox_normalMap.Controls.Add(this.label_normalMapFile);
			this.groupBox_normalMap.Controls.Add(this.button_clearNormalMap);
			this.groupBox_normalMap.Controls.Add(this.button_loadNormalMap);
			this.groupBox_normalMap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox_normalMap.Location = new System.Drawing.Point(3, 649);
			this.groupBox_normalMap.Name = "groupBox_normalMap";
			this.groupBox_normalMap.Size = new System.Drawing.Size(188, 103);
			this.groupBox_normalMap.TabIndex = 4;
			this.groupBox_normalMap.TabStop = false;
			this.groupBox_normalMap.Text = "Normal map";
			// 
			// label_normalMapFile
			// 
			this.label_normalMapFile.AutoSize = true;
			this.label_normalMapFile.Location = new System.Drawing.Point(6, 58);
			this.label_normalMapFile.Name = "label_normalMapFile";
			this.label_normalMapFile.Size = new System.Drawing.Size(58, 15);
			this.label_normalMapFile.TabIndex = 2;
			this.label_normalMapFile.Text = "File name";
			// 
			// button_clearNormalMap
			// 
			this.button_clearNormalMap.Location = new System.Drawing.Point(106, 22);
			this.button_clearNormalMap.Name = "button_clearNormalMap";
			this.button_clearNormalMap.Size = new System.Drawing.Size(75, 23);
			this.button_clearNormalMap.TabIndex = 1;
			this.button_clearNormalMap.Text = "Clear";
			this.button_clearNormalMap.UseVisualStyleBackColor = true;
			// 
			// button_loadNormalMap
			// 
			this.button_loadNormalMap.Location = new System.Drawing.Point(6, 22);
			this.button_loadNormalMap.Name = "button_loadNormalMap";
			this.button_loadNormalMap.Size = new System.Drawing.Size(75, 23);
			this.button_loadNormalMap.TabIndex = 0;
			this.button_loadNormalMap.Text = "Load";
			this.button_loadNormalMap.UseVisualStyleBackColor = true;
			this.button_loadNormalMap.Click += new System.EventHandler(this.button_loadNormalMap_Click);
			// 
			// form_mainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 761);
			this.Controls.Add(this.tableLayoutPanel_main);
			this.MinimumSize = new System.Drawing.Size(1000, 800);
			this.Name = "form_mainWindow";
			this.Text = "Illuminated sphere";
			this.tableLayoutPanel_main.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_workingArea)).EndInit();
			this.tableLayoutPanel_right.ResumeLayout(false);
			this.groupBox_buttons.ResumeLayout(false);
			this.groupBox_parameters.ResumeLayout(false);
			this.groupBox_parameters.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_m)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_ks)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_kd)).EndInit();
			this.groupBox_sun.ResumeLayout(false);
			this.groupBox_sun.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_sunHeight)).EndInit();
			this.groupBox_object.ResumeLayout(false);
			this.groupBox_object.PerformLayout();
			this.groupBox_normalMap.ResumeLayout(false);
			this.groupBox_normalMap.PerformLayout();
			this.ResumeLayout(false);

    }

    #endregion

    private TableLayoutPanel tableLayoutPanel_main;
    private PictureBox pictureBox_workingArea;
	private TableLayoutPanel tableLayoutPanel_right;
	private GroupBox groupBox_buttons;
	private GroupBox groupBox_parameters;
	private GroupBox groupBox_sun;
	private GroupBox groupBox_object;
	private Button button_clear;
	private Button button_redraw;
	private Button button_onePolygon;
	private Button button_outline;
	private Label label_kd;
	private TrackBar trackBar_kd;
	private Label label_mValue;
	private Label label_ksValue;
	private TrackBar trackBar_m;
	private Label label_m;
	private TrackBar trackBar_ks;
	private Label label_ks;
	private Label label_kdValue;
	private TrackBar trackBar_sunHeight;
	private CheckBox checkBox_sunAnimation;
	private Label label_sunHeight;
	private Label label_sunColor;
	private Label label_sunHeightValue;
	private Panel panel_sunColor;
	private Panel panel_objColor;
	private RadioButton radioButton_color;
	private RadioButton radioButton_texture;
	private Button button_texture;
	private RadioButton radioButton_normalInterpolation;
	private RadioButton radioButton_colorInterpolation;
	private GroupBox groupBox_normalMap;
	private Button button_clearNormalMap;
	private Button button_loadNormalMap;
	private Label label_normalMapFile;
}
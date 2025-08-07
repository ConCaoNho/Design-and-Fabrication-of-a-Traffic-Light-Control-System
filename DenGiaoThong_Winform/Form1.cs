using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace DenGiaoThong
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        private bool isPriorityOn = false;
        private string currentPriorityDir = "";
        private bool isAutoMode = true; // Mặc định: đang ở chế độ tự động

        public Form1()
        {
            InitializeComponent();
            LoadPorts();
            txtStatus.Multiline = true;
            txtStatus.ReadOnly = true;

            lblRedTime.Text = (nudYellowTime.Value + nudGreenTime.Value).ToString();
            nudYellowTime.ValueChanged += TimeValueChanged;
            nudGreenTime.ValueChanged += TimeValueChanged;
            nudLeftTime.ValueChanged += TimeValueChanged;

            UpdateRedTime();
            ToggleManualControls(false); // Tắt các nút điều khiển khi chưa bật chế độ thủ công
        }

        private void LoadPorts()
        {
            comboBoxPort.Items.Clear();
            comboBoxPort.Items.AddRange(SerialPort.GetPortNames());
            if (comboBoxPort.Items.Count > 0)
                comboBoxPort.SelectedIndex = 0;
            else
                txtStatus.AppendText("Không tìm thấy cổng COM nào!\r\n");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort == null || !serialPort.IsOpen)
                {
                    if (comboBoxPort.SelectedItem == null)
                    {
                        MessageBox.Show("Vui lòng chọn cổng COM!");
                        return;
                    }
                    txtStatus.AppendText($"Đang thử kết nối tới {comboBoxPort.SelectedItem}...\r\n");
                    serialPort = new SerialPort(comboBoxPort.SelectedItem.ToString(), 115200);
                    serialPort.DataReceived += SerialPort_DataReceived;
                    serialPort.Open();
                    btnConnect.Text = "Disconnect";
                    txtStatus.AppendText("Đã kết nối với ESP32!\r\n");
                }
                else
                {
                    serialPort.Close();
                    btnConnect.Text = "Connect";
                    txtStatus.AppendText("Đã ngắt kết nối!\r\n");
                }
            }
            catch (Exception ex)
            {
                txtStatus.AppendText($"Lỗi kết nối: {ex.Message}\r\n");
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort.ReadLine();
                this.Invoke((MethodInvoker)delegate
                {
                    txtStatus.AppendText(data + "\r\n");
                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    txtStatus.AppendText("Lỗi nhận dữ liệu: " + ex.Message + "\r\n");
                });
            }
        }

        private void btnNightMode_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                if (btnNightMode.Text == "Ban Đêm")
                {
                    serialPort.WriteLine("NIGHT_MODE_ON");
                    btnNightMode.Text = "Tắt Ban Đêm";
                    txtStatus.AppendText("Gửi: NIGHT_MODE_ON\n");
                }
                else
                {
                    serialPort.WriteLine("NIGHT_MODE_OFF");
                    btnNightMode.Text = "Ban Đêm";
                    txtStatus.AppendText("Gửi: NIGHT_MODE_OFF\n");
                }
            }
            else
            {
                MessageBox.Show("Chưa kết nối với ESP32!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                int yellowTime = (int)nudYellowTime.Value;
                int greenTime = (int)nudGreenTime.Value;
                int leftTime = (int)nudLeftTime.Value;
                int redTime = yellowTime + greenTime + leftTime;

                if (redTime > 0 && yellowTime > 0 && greenTime > 0)
                {
                    string command = $"SET_TIMES:{greenTime}:{yellowTime}:{leftTime}";
                    serialPort.WriteLine(command);
                    txtStatus.AppendText($"Gửi: {command}\n");
                    lblRedTime.Text = redTime.ToString();
                }
                else
                {
                    MessageBox.Show("Thời gian phải lớn hơn 0!");
                }
            }
            else
            {
                MessageBox.Show("Chưa kết nối với ESP32!");
            }
        }

        private void btnWarningMode_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                if (btnWarningMode.Text == "Cảnh báo")
                {
                    serialPort.WriteLine("WARNING_MODE_ON");
                    btnWarningMode.Text = "Tắt Cảnh báo";
                    txtStatus.AppendText("Gửi: WARNING_MODE_ON\n");
                }
                else
                {
                    serialPort.WriteLine("WARNING_MODE_OFF");
                    btnWarningMode.Text = "Cảnh báo";
                    txtStatus.AppendText("Gửi: WARNING_MODE_OFF\n");
                }
            }
            else
            {
                MessageBox.Show("Chưa kết nối với ESP32!");
            }
        }

        private void TimeValueChanged(object sender, EventArgs e)
        {
            UpdateRedTime();
        }

        private void UpdateRedTime()
        {
            decimal yellow = nudYellowTime.Value;
            decimal green = nudGreenTime.Value;
            decimal left = nudLeftTime.Value;
            lblRedTime.Text = (yellow + green + left).ToString();
        }

        private void btnPriorityD_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                if (!isPriorityOn || currentPriorityDir != "D")
                {
                    serialPort.WriteLine("PRIORITY_MODE_ON:D");
                    txtStatus.AppendText("Gửi: PRIORITY_MODE_ON:D\n");
                    isPriorityOn = true;
                    currentPriorityDir = "D";
                }
                else
                {
                    serialPort.WriteLine("PRIORITY_MODE_OFF");
                    txtStatus.AppendText("Gửi: PRIORITY_MODE_OFF\n");
                    isPriorityOn = false;
                    currentPriorityDir = "";
                }
            }
            else
            {
                MessageBox.Show("Chưa kết nối với ESP32!");
            }
        }

        private void btnPriorityN_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                if (!isPriorityOn || currentPriorityDir != "N")
                {
                    serialPort.WriteLine("PRIORITY_MODE_ON:N");
                    txtStatus.AppendText("Gửi: PRIORITY_MODE_ON:N\n");
                    isPriorityOn = true;
                    currentPriorityDir = "N";
                }
                else
                {
                    serialPort.WriteLine("PRIORITY_MODE_OFF");
                    txtStatus.AppendText("Gửi: PRIORITY_MODE_OFF\n");
                    isPriorityOn = false;
                    currentPriorityDir = "";
                }
            }
            else
            {
                MessageBox.Show("Chưa kết nối với ESP32!");
            }
        }

        private void btnManualMode_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                if (isAutoMode)
                {
                    serialPort.WriteLine("MANUAL_MODE_ON");
                    txtStatus.AppendText("Gửi: MANUAL_MODE_ON\n");
                    btnManualMode.Text = "Tự động";
                    ToggleManualControls(true); // Bật các nút điều khiển
                }
                else
                {
                    serialPort.WriteLine("MANUAL_MODE_OFF");
                    txtStatus.AppendText("Gửi: MANUAL_MODE_OFF\n");
                    btnManualMode.Text = "Thủ công";
                    ToggleManualControls(false); // Tắt các nút điều khiển
                }

                isAutoMode = !isAutoMode;
            }
            else
            {
                MessageBox.Show("Chưa kết nối với ESP32!");
            }
        }

        // Bật/tắt các nút theo chế độ điều khiển
        private void ToggleManualControls(bool enable)
        {
            btnNightMode.Enabled = enable;
            btnWarningMode.Enabled = enable;
            btnPriorityD.Enabled = enable;
            btnPriorityN.Enabled = enable;
            btnSave.Enabled = enable;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
                serialPort.Close();
            base.OnFormClosing(e);
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
    }
}

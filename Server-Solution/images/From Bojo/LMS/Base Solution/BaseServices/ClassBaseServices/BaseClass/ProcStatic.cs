using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;

namespace BaseServices
{
    public partial class ProcStatic
    {
        #region Programmer-Defined Void Procedures

        //this procedure sets the dataview headers
        public static void SetDataGridViewColumns(DataGridView dgvBase, Boolean useSize)
        {
            Int32 width = 0;

            //general datagridview settings
            dgvBase.ReadOnly = true;
            dgvBase.MultiSelect = false;
            //----------------------

            foreach (DataGridViewColumn column in dgvBase.Columns)
            {
                //general column settings
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                //----------------------------

                //individual column setting
                switch (column.HeaderText)
                {
                    case "beneficiary_reference_id":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "office_employer_id":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "member_id":
                        column.HeaderText = "Member ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "sysid_person":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "person_name":
                        column.HeaderText = "Name";
                        column.Width = 300;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "member_name":
                        column.HeaderText = "Name";
                        column.Width = 300;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "relationship_description":
                        column.HeaderText = "Relationship Description";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "present_address":
                        column.HeaderText = "Present Address";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "home_address":
                        column.HeaderText = "Home Address";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "home_phone_nos":
                        column.HeaderText = "Home Phone No.";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "birthdate":
                        column.HeaderText = "BirthDate";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "present_phone_nos":
                        column.HeaderText = "Present Phone No.";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "office_employer_name":
                        column.HeaderText = "Office Name";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "office_employer_acronym":
                        column.HeaderText = "Office Acronym ";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "office_employer_address":
                        column.HeaderText = "Office Address ";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "office_employer_phone_nos":
                        column.HeaderText = "Office Phone No.";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "life_status_code_code_description":
                        column.HeaderText = "Life Status";
                        column.Width = 100;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "gender_code_code_description":
                        column.HeaderText = "Gender";
                        column.Width = 100;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "occupation":
                        column.HeaderText = "Occupation";
                        column.Width = 100;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "acronym":
                        column.HeaderText = "Acronym";
                        column.Width = 100;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    default:
                        column.Visible = false;
                        column.Width = 0;
                        break;
                }

                width += column.Width;
            }

            if (useSize)
            {
                dgvBase.Width = width;
            }

        } //---------------------------

        //this procedure sets the textbox initial message
        public static void TextBoxMessageTip(TextBox txtInput, String strMessage, Boolean showMessage)
        {
            String strInput = txtInput.Text.Trim();

            if (showMessage && (String.Equals(strInput, "") || strInput == null))
            {
                txtInput.Text = strMessage;
                txtInput.Font = new Font(txtInput.Font, FontStyle.Italic);
                txtInput.ForeColor = Color.DarkCyan;
            }
            else
            {
                if (String.Equals(strInput, strMessage) || strInput == null)
                {
                    txtInput.Text = "";
                }

                txtInput.Font = new Font(txtInput.Font, FontStyle.Regular);
                txtInput.ForeColor = Color.Black;
            }

        } //--------------------------

        //this procedure makes the textbox accept on numbers
        public static void TextBoxAmountOnly(KeyPressEventArgs e)
        {
            if (e.KeyChar != '.' && e.KeyChar != ',' && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        } //------------------------------

        //this procedure makes the textbox accept letters only
        public static void TextBoxLettersOnly(KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        } //-----------------------------

        //this procedure makes the textbox accept integers only
        public static void TextBoxIntegersOnly(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        } //------------------------------

        //this procedure validates the textbox
        public static void TextBoxValidateAmount(TextBox txtInput)
        {
            Decimal input;

            if (Decimal.TryParse(txtInput.Text, out input))
            {
                txtInput.Text = input.ToString("N");
            }
            else
            {
                txtInput.Text = "0.00";
            }

        } //--------------------------------------

        //this procedure validates the textbox
        public static void TextBoxValidateInteger(TextBox txtInput)
        {
            Int32 input;

            if (Int32.TryParse(txtInput.Text, out input))
            {
                txtInput.Text = input.ToString();
            }
            else
            {
                txtInput.Text = "0";
            }

        } //--------------------------------------

        //this function deletes a specified directory
        public static void DeleteDirectory(String dirPath)
        {
            DirectoryInfo infoDir = new DirectoryInfo(dirPath);

            if (infoDir.Exists)
            {
                infoDir.Delete(true);
            }
        } //-----------------------------------

        //this function shows an error message
        public static void ShowErrorDialog(String errMsg, String errCaption)
        {
            MessageBox.Show("A business rule has been violated... \nDetails: " + errMsg, errCaption,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        } //-------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the array of bytes of a file
        public static Byte[] GetFileArrayBytes(String filePath)
        {
            FileStream fileStr = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader binReader = new BinaryReader(fileStr);

            Byte[] fileByte = binReader.ReadBytes((Int32)fileStr.Length);

            fileStr.Close();
            binReader.Close();

            fileStr = null;
            binReader = null;

            return fileByte;

        } //--------------------------

        //this function trims the special characters
        public static String TrimStartEndString(String strBase)
        {
            if (!String.IsNullOrEmpty(strBase))
            {
                return strBase.TrimStart(null).TrimEnd(null);
            }
            else
            {
                return "";
            }

        } //-----------------------

        //this function gets the complete name
        public static String GetCompleteNameMiddleInitial(DataRow srcRow, String colLName, String colFName, String colMName)
        {
            return RemoteServerLib.ProcStatic.DataRowConvert(srcRow, colLName, "").ToUpper() + ", " +
                RemoteServerLib.ProcStatic.DataRowConvert(srcRow, colFName, "") + " " +
                (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(srcRow, colMName, "")) ? "" :
                (RemoteServerLib.ProcStatic.DataRowConvert(srcRow, colMName, "").Substring(0, 1).ToUpper() + "."));
        } //------------------------------        

        //this function gets the complete name
        public static String GetCompleteNameMiddleInitial(String lName, String fName, String mName)
        {
            return lName.ToUpper() + ", " + fName + " " + (String.IsNullOrEmpty(mName) ? "" : (mName.Substring(0, 1).ToUpper() + "."));
        } //------------------------------   

        //this function gets the complete name
        public static String GetCompleteNameMiddleInitial(DataRow srcRow, String colPreFix, String colLName, String colFName, String colMName, String colSuFix)
        {
            return RemoteServerLib.ProcStatic.DataRowConvert(srcRow, colPreFix, "") + " " +
                RemoteServerLib.ProcStatic.DataRowConvert(srcRow, colFName, "") + " " +
                (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(srcRow, colMName, "")) ? "" :
                (RemoteServerLib.ProcStatic.DataRowConvert(srcRow, colMName, "").Substring(0, 1).ToUpper() + ".")) + " " +
                 RemoteServerLib.ProcStatic.DataRowConvert(srcRow, colLName, "") + ", " +
                 RemoteServerLib.ProcStatic.DataRowConvert(srcRow, colSuFix, "");
        } //------------------------------ 

        //this function gets the complete name
        public static String GetCompleteNameMiddleInitial(String preFix, String lName, String fName, String mName, String suFix)
        {
            String tempPrefix = String.IsNullOrEmpty(preFix) ? String.Empty : preFix;
            String tempSuffix = String.IsNullOrEmpty(suFix) ? String.Empty : suFix;

            tempPrefix = tempPrefix.Replace(".", "");
            tempPrefix = !String.IsNullOrEmpty(tempPrefix) ? preFix + ". " : String.Empty;
            tempSuffix = tempSuffix.Replace(",", "");
            tempSuffix = !String.IsNullOrEmpty(tempSuffix) ? ", " + suFix : String.Empty;

            return tempPrefix + " " + fName + "  " + (String.IsNullOrEmpty(mName) ? "" : (mName.Substring(0, 1).ToUpper() + ".")) + " " +
                lName + tempSuffix;
        } //------------------------------   

        //this function returns the network information
        public static String GetNetworkInformation()
        {
            StringBuilder strNetInfo = new StringBuilder();

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

                strNetInfo.Append("Windows IP Configuration: " + "\n\n");
                strNetInfo.Append("\t" + "Host Name...........................: " + computerProperties.HostName + "\n");
                strNetInfo.Append("\t" + "Domain Name.........................: " + computerProperties.DomainName + "\n");

                if (nics == null || nics.Length < 1)
                {
                    strNetInfo.Append("\n" + "No network interface found.");
                }
                else
                {
                    foreach (NetworkInterface adapter in nics)
                    {
                        if (!adapter.Supports(NetworkInterfaceComponent.IPv4))
                        {
                            continue;
                        }

                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        IPv4InterfaceProperties ipV4 = properties.GetIPv4Properties();

                        strNetInfo.Append("\n" + adapter.NetworkInterfaceType + " Adapter " + adapter.Name + "\n");
                        strNetInfo.Append("\t" + "Description.........................: " + adapter.Description + "\n");
                        strNetInfo.Append("\t" + "Physical Address....................: ");

                        PhysicalAddress address = adapter.GetPhysicalAddress();
                        Byte[] bytes = address.GetAddressBytes();

                        for (int i = 0; i < bytes.Length; i++)
                        {
                            strNetInfo.Append(bytes[i].ToString("X2"));

                            if (i != bytes.Length - 1)
                            {
                                strNetInfo.Append("-");
                            }
                        }

                        if (ipV4 == null)
                        {
                            strNetInfo.Append("\n");
                            strNetInfo.Append("\t" + "No IPv4 information is available for this interface.");
                            continue;
                        }

                        strNetInfo.Append("\n");
                        strNetInfo.Append("\t" + "IP Address..........................: ");

                        foreach (UnicastIPAddressInformation ipInfo in properties.UnicastAddresses)
                        {
                            strNetInfo.Append(ipInfo.Address);
                            strNetInfo.Append("   ");
                        }

                        strNetInfo.Append("\n");
                        strNetInfo.Append("\t" + "Gateway Addresses...................: ");

                        foreach (GatewayIPAddressInformation gateway in properties.GatewayAddresses)
                        {
                            strNetInfo.Append(gateway.Address);
                            strNetInfo.Append("   ");
                        }
                        strNetInfo.Append("\n");
                        strNetInfo.Append("\t" + "DNS Servers.........................: ");

                        foreach (IPAddress ipInfo in properties.DnsAddresses)
                        {
                            bytes = ipInfo.GetAddressBytes();

                            for (int i = 0; i < bytes.Length; i++)
                            {
                                strNetInfo.Append(bytes[i].ToString());

                                if (i != bytes.Length - 1)
                                {
                                    strNetInfo.Append(".");
                                }
                            }

                            strNetInfo.Append("   ");
                        }

                        strNetInfo.Append("\n");
                    }
                }

            }
            else
            {
                strNetInfo.Append("Using LOCALHOST network information");
            }

            return strNetInfo.ToString();

        } //----------------------------

         #endregion
    }
}

// создаём форму с указанным значением
var dialogForm = new System.Windows.Forms.Form { Size = new Size(203, 110), ShowIcon = false, Name = "DialogForm", Text = @"Введите смс код",
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog, MinimizeBox = false, MaximizeBox = false };
           
// поле ввода
var textBox = new System.Windows.Forms.TextBox { Name = "InputText", Size = new Size(165, 20) };
// кладём не форму
dialogForm.Controls.Add(textBox);
// положение на форме
textBox.Location = new Point(12, 12);
 
// кнопка ok
var okButton = new System.Windows.Forms.Button { Name = "OKButton", Text = @"OK", Size = new Size(75, 23) };
// кладём не форму
dialogForm.Controls.Add(okButton);
// положение на форме
okButton.Location = new Point(20, 38);
// обработка события
okButton.Click += (delegate { dialogForm.DialogResult = System.Windows.Forms.DialogResult.OK; });
 
// кнопка отмены
var cancelButton = new System.Windows.Forms.Button { Name = "CancelButton", Text = @"Отмена", Size = new Size(75, 23)};
// кладём не форму
dialogForm.Controls.Add(cancelButton);
// положение на форме
cancelButton.Location = new Point(100, 38);
// обработка события
cancelButton.Click += (delegate { dialogForm.DialogResult = System.Windows.Forms.DialogResult.Cancel; });
 
// показывем форму
var dialogResult = dialogForm.ShowDialog();
// если не было отмены диалога
if (dialogResult != System.Windows.Forms.DialogResult.Cancel) return project.Variables["sms"].Value = textBox.Text.ToString();
project.SendErrorToLog("","Данные не введены",true);
throw new Exception ("Данные не введены");
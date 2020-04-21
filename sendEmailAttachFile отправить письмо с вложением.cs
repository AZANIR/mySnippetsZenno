//http://zennolab.com/discussion/threads/otpravka-email-cherez-c-makros.10874/

// с какого email отправлять
var fromEmailString = project.Variables["fromEmail"].Value;
// куда отправлять
var toEmailString = project.Variables["toEmail"].Value;
// логин для авторизации на сервере отправки письма
var login = project.Variables["login"].Value;
// пароль от email, от имени которого отправляем письмо
var password = project.Variables["password"].Value;
// сервер, через который отправляем письмо
var server = project.Variables["server"].Value;
// порт сервера, через который отправляем письмо
int port;
int.TryParse(project.Variables["port"].Value, out port);
// нужно ли шифровать подключение (например для gmail нужно)
bool encryptConnection;
bool.TryParse(project.Variables["encryptedConnection"].Value, out encryptConnection);
// текст письма
var messageText = project.Variables["messageBody"].Value;
// заголовок письма
var messageSubject = project.Variables["messageSubject"].Value;
// файл, который нужно приложить, если ничего не нужно прикладывать, оставляем переменную пустой
var fileToAttach = project.Variables["fileToAttach"].Value;
 
// Формирование реквизитов письма
var fromAddress = new System.Net.Mail.MailAddress(fromEmailString, fromEmailString);
var toAddress = new System.Net.Mail.MailAddress(toEmailString, toEmailString);
// создаем подключение к почтовому серверу
var smtp = new System.Net.Mail.SmtpClient {
                            Host = server,
                            Port = port,
                            EnableSsl = encryptConnection,
                            DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new System.Net.NetworkCredential(login, password)
                        };
// создаем письмо
var message = new System.Net.Mail.MailMessage(fromAddress, toAddress) {
                                        Subject = messageSubject,
                                        Body = messageText,
                                        IsBodyHtml = false,
                                    };
// если у нас есть вложение, то добавляем его
if (!string.IsNullOrEmpty(fileToAttach))
{
    var attach = new System.Net.Mail.Attachment(fileToAttach);
    message.Attachments.Add(attach);
}
smtp.Send(message);
message.Dispose();
 
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace SRP_Console.Model
{
    //Invoice class is responsible for managing invoices,
    public class Invoice
    {
        public long InvoiceAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        EmailSender EmailSender { get; set; } = new EmailSender();
        public void AddInvoice(EmailSender emailSender )
        {
            try
            {
                // Here we need to write the Code for adding invoice
                Console.WriteLine("Adding invoice: Amount = {0}, Date = {1}", InvoiceAmount, InvoiceDate);
                // Once the Invoice has been added, then send the  mail
                EmailSender.SendInvoiceEmail("EMailFrom", "EMailTo", "EMailSubject", "EMailBody");
                //emailSender.SendInvoiceEmail(mailMessage);
            }
            catch (Exception ex)
            {
                //Error Logging
                ErrorLogger.Log(ex);
            }
        }
        public void DeleteInvoice()
        {
            try
            {
                //Here we need to write the Code for Deleting the already generated invoice
                Console.WriteLine("Deleting invoice: Amount = {0}, Date = {1}", InvoiceAmount, InvoiceDate);
            }
            catch (Exception ex)
            {
                //Error Logging
                ErrorLogger.Log(ex);
            }
        }
       
    }

    //EmailSender Class responsible for sending emails.
    public class EmailSender
    {
        public string EMailFrom { get; set; }
        public string EMailTo { get; set; }
        public string EMailSubject { get; set; }
        public string EMailBody { get; set; }
        public EmailSender(string EMailFrom, string EMailTo, string EMailSubject, string EMailBody)
        {

        }
        public EmailSender()
        {

        }
        public void SendInvoiceEmail()
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                // Code for sending email
                using (SmtpClient smtpClient = new SmtpClient("smtp.example.com"))
                {
                    smtpClient.Send(mailMessage);
                    Console.WriteLine("Email sent successfully.");
                }
            }
            catch (Exception ex)
            {
                // Error Logging
                ErrorLogger.Log(ex);
            }
        }
        public void SendInvoiceEmail(string EMailFrom, string EMailTo, string EMailSubject, string EMailBody)
        {
            try
            {
                MailMessage mailMessage = new MailMessage(EMailFrom, EMailTo, EMailSubject, EMailBody);
                // Code for sending email
                using (SmtpClient smtpClient = new SmtpClient("smtp.example.com"))
                {
                    smtpClient.Send(mailMessage);
                    Console.WriteLine("Email sent successfully.");
                }
            }
            catch (Exception ex)
            {
                // Error Logging
                ErrorLogger.Log(ex);
            }
        }
    }

    //ErrorLogger Class for handling error logging
    public static class ErrorLogger
    {
        public static void Log(Exception ex)
        {
            // Code for logging errors
            File.WriteAllText(@"c:\ErrorLog.txt", ex.ToString());
        }
    }

 
}

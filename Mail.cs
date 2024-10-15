using (var client = new Pop3Client())
{
    try
    {  
        client.Connect("gunmail.xyz", 110, MailKit.Security.SecureSocketOptions.None);
        client.Authenticate("hanv@gunmail.xyz", "12345678");
        int messageCount = client.Count;
        Console.WriteLine($"Total messages: {messageCount}");
        for (int i = 0; i < messageCount; i++)
        {
            MimeMessage message = client.GetMessage(i);

            Console.WriteLine($"Subject: {message.Subject}");
            Console.WriteLine($"From: {message.From}");
            Console.WriteLine($"Date: {message.Date}");
            Console.WriteLine("--------------------------------------------");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
    
    finally
    {
        // Disconnect from the server
        client.Disconnect(true);
    }
}

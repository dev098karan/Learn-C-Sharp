using System;
using System.Drawing;
using System.Windows.Forms;

public class ToastNotification
{
    public static void Show(string message, int duration = 3000)
    {
        Form toast = new Form();
        toast.FormBorderStyle = FormBorderStyle.None;
        toast.StartPosition = FormStartPosition.Manual;
        toast.BackColor = Color.AliceBlue;
        toast.ForeColor = Color.AliceBlue;
        toast.Width = 300;
        toast.Height = 80;
        toast.TopMost = true;
        toast.ShowInTaskbar = false;

        // Position in bottom-right corner of screen
        Rectangle screen = Screen.PrimaryScreen.WorkingArea;
        toast.Location = new Point(screen.Right - toast.Width - 10, screen.Bottom - toast.Height - 10);

        // Add label for message
        Label lblMessage = new Label();
        lblMessage.Text = message;
        lblMessage.ForeColor = Color.Green;
        lblMessage.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        lblMessage.AutoSize = false;
        lblMessage.Dock = DockStyle.Fill;
        lblMessage.TextAlign = ContentAlignment.MiddleCenter;

        toast.Controls.Add(lblMessage);

        // Timer for auto-close
        Timer timer = new Timer();
        timer.Interval = duration; // duration in ms
        timer.Tick += (s, e) =>
        {
            timer.Stop();
            toast.Close();
        };

        // Fade-in effect (optional)
        toast.Opacity = 0;
        Timer fadeTimer = new Timer();
        fadeTimer.Interval = 20;
        fadeTimer.Tick += (s, e) =>
        {
            if (toast.Opacity < 1)
                toast.Opacity += 0.05;
            else
                fadeTimer.Stop();
        };

        timer.Start();
        fadeTimer.Start();
        toast.Show();
    }
}

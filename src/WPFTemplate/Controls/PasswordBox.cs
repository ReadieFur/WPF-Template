using System;
using System.Security;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    //Tweaked from: https://stackoverflow.com/questions/17407620/custom-masked-passwordbox-in-wpf
    public class PasswordBox : TextBox
    {
        #region Hidden base class properties
        [Obsolete("This property is not supported. Use PasswordChar instead.", true)]
        new public string Text
        {
            get => base.Text;
            //private set => base.Text = value;
            set => base.Text = value;
        }
        #endregion

        #region Member Variables
        public static readonly DependencyProperty PasswordCharProperty = DependencyExt.RegisterDependencyProperty<PasswordBox, char>(nameof(PasswordChar), '●');
        public char PasswordChar { get => (char)GetValue(PasswordCharProperty); set => SetValue(PasswordCharProperty, value); }

        public static readonly DependencyProperty PasswordProperty =
          DependencyProperty.Register(
            "Password", typeof(SecureString), typeof(PasswordBox), new UIPropertyMetadata(new SecureString()));

        /// <summary>
        ///   Private member holding mask visibile timer
        /// </summary>
        private readonly DispatcherTimer _maskTimer;
        #endregion

        #region Constructors
        /// <summary>
        ///   Initialises a new instance of the LifeStuffPasswordBox class.
        /// </summary>
        public PasswordBox()
        {
            PreviewTextInput += OnPreviewTextInput;
            PreviewKeyDown += OnPreviewKeyDown;
            CommandManager.AddPreviewExecutedHandler(this, PreviewExecutedHandler);
            _maskTimer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 1) };
            _maskTimer.Tick += (sender, args) => MaskAllDisplayText();
        }
        #endregion

        #region Commands & Properties
        /// <summary>
        ///   Gets or sets dependency Property implementation for Password
        /// </summary>
        public SecureString Password
        {
            get => (SecureString)GetValue(PasswordProperty);
            set => SetValue(PasswordProperty, value);
        }
        #endregion

        #region Methods
        /// <summary>
        ///   Method to handle PreviewExecutedHandler events
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="executedRoutedEventArgs">Event Text Arguments</param>
        private static void PreviewExecutedHandler(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            if (executedRoutedEventArgs.Command == ApplicationCommands.Copy ||
                executedRoutedEventArgs.Command == ApplicationCommands.Cut ||
                executedRoutedEventArgs.Command == ApplicationCommands.Paste)
                executedRoutedEventArgs.Handled = true;
        }

        /// <summary>
        ///   Method to handle PreviewTextInput events
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="textCompositionEventArgs">Event Text Arguments</param>
        private void OnPreviewTextInput(object sender, TextCompositionEventArgs textCompositionEventArgs)
        {
            AddToSecureString(textCompositionEventArgs.Text);
            textCompositionEventArgs.Handled = true;
        }

        /// <summary>
        ///   Method to handle PreviewKeyDown events
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="keyEventArgs">Event Text Arguments</param>
        private void OnPreviewKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            Key pressedKey = keyEventArgs.Key == Key.System ? keyEventArgs.SystemKey : keyEventArgs.Key;
            switch (pressedKey)
            {
                case Key.Space:
                    AddToSecureString(" ");
                    keyEventArgs.Handled = true;
                    break;
                case Key.Back:
                case Key.Delete:
                    if (SelectionLength > 0) RemoveFromSecureString(SelectionStart, SelectionLength);
                    else if (pressedKey == Key.Delete && CaretIndex < base.Text.Length) RemoveFromSecureString(CaretIndex, 1);
                    else if (pressedKey == Key.Back && CaretIndex > 0)
                    {
                        int caretIndex = CaretIndex;
                        if (CaretIndex > 0 && CaretIndex < base.Text.Length)
                            caretIndex = caretIndex - 1;
                        RemoveFromSecureString(CaretIndex - 1, 1);
                        CaretIndex = caretIndex;
                    }

                    keyEventArgs.Handled = true;
                    break;
            }
        }

        /// <summary>
        ///   Method to add new text into SecureString and process visual output
        /// </summary>
        /// <param name="text">Text to be added</param>
        private void AddToSecureString(string text)
        {
            if (SelectionLength > 0) RemoveFromSecureString(SelectionStart, SelectionLength);

            foreach (char c in text)
            {
                int caretIndex = CaretIndex;
                Password.InsertAt(caretIndex, c);
                MaskAllDisplayText();
                if (caretIndex == base.Text.Length)
                {
                    _maskTimer.Stop();
                    _maskTimer.Start();
                    base.Text = base.Text.Insert(caretIndex++, c.ToString());
                }
                else base.Text = base.Text.Insert(caretIndex++, PasswordChar.ToString());
                CaretIndex = caretIndex;
            }
        }

        /// <summary>
        ///   Method to remove text from SecureString and process visual output
        /// </summary>
        /// <param name="startIndex">Start Position for Remove</param>
        /// <param name="trimLength">Length of Text to be removed</param>
        private void RemoveFromSecureString(int startIndex, int trimLength)
        {
            int caretIndex = CaretIndex;
            for (int i = 0; i < trimLength; ++i) Password.RemoveAt(startIndex);
            
            base.Text = base.Text.Remove(startIndex, trimLength);
            CaretIndex = caretIndex;
        }

        private void MaskAllDisplayText()
        {
            _maskTimer.Stop();
            int caretIndex = CaretIndex;
            base.Text = new string(PasswordChar, base.Text.Length);
            CaretIndex = caretIndex;
        }
        #endregion
    }
}

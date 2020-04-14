﻿using _7thHeaven.Code;
using Iros._7th.Workshop;
using SeventhHeaven.Classes;
using SeventhHeaven.Windows;
using SeventhHeavenUI;
using SeventhHeavenUI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using XInputDotNetPure;

namespace SeventhHeaven.ViewModels
{

    public class ControlMappingViewModel : ViewModelBase
    {
        private enum CaptureState
        {
            NotCapturing,
            CaptureKeyboard,
            CaptureController
        }

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private List<string> _defaultControlNames = new List<string>()
        {
            "1998 KB+Std Gamepad",
            "1998 KB+Swap AB-XO Gamepad",
            "1998 Original",
            "No Numpad+Std Gamepad",
            "No Numpad+Swap AB-XO Gamepad",
            "Steam KB+Std GamePad",
            "Steam KB+Swap AB-XO GamePad",
            "Steam Original",
            "WASD unab0mb's Choice Std",
            "WASD unab0mb's Choice Swap"
        };

        private string _okControllerText;
        private bool _isCapturing;
        private GameControl _controlToCapture;
        private CaptureState _captureState;
        private string _okKeyboardText;
        private string _cancelKeyboardText;
        private string _menuKeyboardText;
        private string _switchKeyboardText;
        private string _pageUpKeyboardText;
        private string _pageDownKeyboardText;
        private string _cameraKeyboardText;
        private string _targetKeyboardText;
        private string _assistKeyboardText;
        private string _startKeyboardText;
        private string _upKeyboardText;
        private string _downKeyboardText;
        private string _leftKeyboardText;
        private string _rightKeyboardText;
        private string _selectedGameConfigOption;
        private bool _hasUnsavedChanges;
        private string _cancelControllerText;
        private string _menuControllerText;
        private string _switchControllerText;
        private string _pageUpControllerText;
        private string _pageDownControllerText;
        private string _cameraControllerText;
        private string _targetControllerText;
        private string _startControllerText;
        private string _upControllerText;
        private string _assistControllerText;
        private string _downControllerText;
        private string _leftControllerText;
        private string _rightControllerText;

        private ControlConfiguration LoadedConfiguration { get; set; }

        public string OkControllerText
        {
            get
            {
                return _okControllerText;
            }
            set
            {
                _okControllerText = value;
                NotifyPropertyChanged();
            }
        }

        public string OkKeyboardText
        {
            get
            {
                return _okKeyboardText;
            }
            set
            {
                _okKeyboardText = value;
                NotifyPropertyChanged();
            }
        }


        public string CancelKeyboardText
        {
            get
            {
                return _cancelKeyboardText;
            }
            set
            {
                _cancelKeyboardText = value;
                NotifyPropertyChanged();
            }
        }

        public string MenuKeyboardText
        {
            get
            {
                return _menuKeyboardText;
            }
            set
            {
                _menuKeyboardText = value;
                NotifyPropertyChanged();
            }
        }

        public string SwitchKeyboardText
        {
            get
            {
                return _switchKeyboardText;
            }
            set
            {
                _switchKeyboardText = value;
                NotifyPropertyChanged();
            }
        }

        public string PageUpKeyboardText
        {
            get
            {
                return _pageUpKeyboardText;
            }
            set
            {
                _pageUpKeyboardText = value;
                NotifyPropertyChanged();
            }
        }

        public string PageDownKeyboardText
        {
            get
            {
                return _pageDownKeyboardText;
            }
            set
            {
                _pageDownKeyboardText = value;
                NotifyPropertyChanged();
            }
        }

        public string CameraKeyboardText
        {
            get
            {
                return _cameraKeyboardText;
            }
            set
            {
                _cameraKeyboardText = value;
                NotifyPropertyChanged();
            }
        }

        public string TargetKeyboardText
        {
            get
            {
                return _targetKeyboardText;
            }
            set
            {
                _targetKeyboardText = value;
                NotifyPropertyChanged();
            }
        }

        public string AssistKeyboardText
        {
            get
            {
                return _assistKeyboardText;
            }
            set
            {
                _assistKeyboardText = value;
                NotifyPropertyChanged();
            }
        }

        public string StartKeyboardText
        {
            get
            {
                return _startKeyboardText;
            }
            set
            {
                _startKeyboardText = value;
                NotifyPropertyChanged();
            }
        }

        public string UpKeyboardText
        {
            get
            {
                return _upKeyboardText;
            }
            set
            {
                _upKeyboardText = value;
                NotifyPropertyChanged();
            }
        }

        public string DownKeyboardText
        {
            get
            {
                return _downKeyboardText;
            }
            set
            {
                _downKeyboardText = value;
                NotifyPropertyChanged();
            }
        }

        public string LeftKeyboardText
        {
            get
            {
                return _leftKeyboardText;
            }
            set
            {
                _leftKeyboardText = value;
                NotifyPropertyChanged();
            }
        }

        public string RightKeyboardText
        {
            get
            {
                return _rightKeyboardText;
            }
            set
            {
                _rightKeyboardText = value;
                NotifyPropertyChanged();
            }
        }

        public string CancelControllerText
        {
            get
            {
                return _cancelControllerText;
            }
            set
            {
                _cancelControllerText = value;
                NotifyPropertyChanged();
            }
        }

        public string MenuControllerText
        {
            get
            {
                return _menuControllerText;
            }
            set
            {
                _menuControllerText = value;
                NotifyPropertyChanged();
            }
        }

        public string SwitchControllerText
        {
            get
            {
                return _switchControllerText;
            }
            set
            {
                _switchControllerText = value;
                NotifyPropertyChanged();
            }
        }

        public string PageUpControllerText
        {
            get
            {
                return _pageUpControllerText;
            }
            set
            {
                _pageUpControllerText = value;
                NotifyPropertyChanged();
            }
        }

        public string PageDownControllerText
        {
            get
            {
                return _pageDownControllerText;
            }
            set
            {
                _pageDownControllerText = value;
                NotifyPropertyChanged();
            }
        }

        public string CameraControllerText
        {
            get
            {
                return _cameraControllerText;
            }
            set
            {
                _cameraControllerText = value;
                NotifyPropertyChanged();
            }
        }

        public string TargetControllerText
        {
            get
            {
                return _targetControllerText;
            }
            set
            {
                _targetControllerText = value;
                NotifyPropertyChanged();
            }
        }

        public string AssistControllerText
        {
            get
            {
                return _assistControllerText;
            }
            set
            {
                _assistControllerText = value;
                NotifyPropertyChanged();
            }
        }

        public string StartControllerText
        {
            get
            {
                return _startControllerText;
            }
            set
            {
                _startControllerText = value;
                NotifyPropertyChanged();
            }
        }

        public string UpControllerText
        {
            get
            {
                return _upControllerText;
            }
            set
            {
                _upControllerText = value;
                NotifyPropertyChanged();
            }
        }

        public string DownControllerText
        {
            get
            {
                return _downControllerText;
            }
            set
            {
                _downControllerText = value;
                NotifyPropertyChanged();
            }
        }

        public string LeftControllerText
        {
            get
            {
                return _leftControllerText;
            }
            set
            {
                _leftControllerText = value;
                NotifyPropertyChanged();
            }
        }

        public string RightControllerText
        {
            get
            {
                return _rightControllerText;
            }
            set
            {
                _rightControllerText = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsCapturing
        {
            get
            {
                return _isCapturing;
            }
            set
            {
                _isCapturing = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(IsNotCapturing));
            }
        }

        public bool IsNotCapturing
        {
            get
            {
                return !_isCapturing;
            }
        }

        public bool HasUnsavedChanges
        {
            get
            {
                return _hasUnsavedChanges;
            }
            set
            {
                _hasUnsavedChanges = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(ApplyButtonIsEnabled));
            }
        }

        public bool ApplyButtonIsEnabled
        {
            get
            {
                return HasUnsavedChanges && IsCustomConfigOptionSelected;
            }
        }


        public List<string> InGameConfigOptions
        {
            get
            {
                return InGameConfigurationMap.Keys.ToList();
            }
        }

        public Dictionary<string, string> InGameConfigurationMap { get; set; }

        public string SelectedGameConfigOption
        {
            get
            {
                return _selectedGameConfigOption;
            }
            set
            {
                _selectedGameConfigOption = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(IsCustomConfigOptionSelected));

                if (_selectedGameConfigOption != null)
                {
                    SetSelectedConfigOptionInLaunchSettings();
                    LoadSelectedConfiguration();
                    IsCapturing = false;
                }
            }
        }

        public bool IsCustomConfigOptionSelected
        {
            get
            {
                return !_defaultControlNames.Any(s => s.Equals(SelectedGameConfigOption, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public ControlMappingViewModel()
        {
            _captureState = CaptureState.NotCapturing;

            InitInGameConfigOptions();

            SelectedGameConfigOption = InGameConfigurationMap.Where(s => s.Value == Sys.Settings.GameLaunchSettings.InGameConfigOption)
                                                             .Select(c => c.Key)
                                                             .FirstOrDefault();

            if (string.IsNullOrWhiteSpace(SelectedGameConfigOption))
            {
                // default to first option if their previous option is missing
                SelectedGameConfigOption = InGameConfigOptions[0];
            }

            LoadSelectedConfiguration();
        }

        private void LoadSelectedConfiguration()
        {
            LoadedConfiguration = ControlMapper.LoadConfigurationFromFile(Path.Combine(Sys.PathToControlsFolder, InGameConfigurationMap[SelectedGameConfigOption]));
            UpdateAllButtonText();
            HasUnsavedChanges = false;
        }

        private void InitInGameConfigOptions()
        {
            Dictionary<string, string> configOptions = new Dictionary<string, string>();

            if (!Directory.Exists(Sys.PathToControlsFolder))
            {
                Logger.Warn($"Controls folder missing. creating {Sys.PathToControlsFolder}");
                Directory.CreateDirectory(Sys.PathToControlsFolder);
            }

            foreach (string filePath in Directory.GetFiles(Sys.PathToControlsFolder, "*.cfg").OrderBy(s => s))
            {
                FileInfo info = new FileInfo(filePath);
                configOptions.Add(Path.GetFileNameWithoutExtension(filePath), info.Name);
            }

            InGameConfigurationMap = configOptions;
            NotifyPropertyChanged(nameof(InGameConfigOptions));
        }

        /// <summary>
        /// Saves which input configuration to use in-game (saves back to <see cref="Sys.Settings.GameLaunchSettings"/>)
        /// </summary>
        internal void SetSelectedConfigOptionInLaunchSettings()
        {
            try
            {
                Sys.Settings.GameLaunchSettings.InGameConfigOption = InGameConfigurationMap[SelectedGameConfigOption];
                Sys.SaveSettings();
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }

        internal bool SetControlIfCapturing(System.Windows.Input.Key key)
        {
            if (!IsCapturing || _captureState != CaptureState.CaptureKeyboard)
            {
                return false;
            }

            LoadedConfiguration.SetKeyboardInput(_controlToCapture, key);

            UpdateAllButtonText();

            IsCapturing = false;
            HasUnsavedChanges = true;
            _captureState = CaptureState.NotCapturing;
            return true;
        }

        internal bool SetControlIfCapturing(GamePadButton pressedButton)
        {
            if (!IsCapturing || _captureState != CaptureState.CaptureController)
            {
                return false;
            }

            LoadedConfiguration.SetControllerInput(_controlToCapture, pressedButton);

            UpdateAllButtonText();

            IsCapturing = false;
            _captureState = CaptureState.NotCapturing;
            HasUnsavedChanges = true;
            return true;
        }

        internal bool SetNumpadEnterControlIfCapturing()
        {
            if (!IsCapturing)
            {
                return false;
            }

            ControlInputSetting numpadEnterSetting = ControlMapper.ControlInputs.Where(c => c.DisplayText == "NUMPADENTER").FirstOrDefault();
            LoadedConfiguration.SetKeyboardInput(_controlToCapture, numpadEnterSetting);

            UpdateAllButtonText();

            IsCapturing = false;
            HasUnsavedChanges = true;
            _captureState = CaptureState.NotCapturing;
            return true;
        }


        private void UpdateAllButtonText()
        {
            foreach (GameControl item in Enum.GetValues(typeof(GameControl)).Cast<GameControl>())
            {
                UpdateButtonText(item);
            }
        }

        private void UpdateButtonText(GameControl controlToUpdate)
        {
            Dictionary<GameControl, string> propertiesToUpdate = new Dictionary<GameControl, string>()
            {
                { GameControl.Ok, nameof(OkKeyboardText) },
                { GameControl.Cancel, nameof(CancelKeyboardText) },
                { GameControl.Menu, nameof(MenuKeyboardText) },
                { GameControl.Switch, nameof(SwitchKeyboardText) },
                { GameControl.Pageup, nameof(PageUpKeyboardText) },
                { GameControl.Pagedown, nameof(PageDownKeyboardText) },
                { GameControl.Camera, nameof(CameraKeyboardText) },
                { GameControl.Target, nameof(TargetKeyboardText) },
                { GameControl.Assist, nameof(AssistKeyboardText) },
                { GameControl.Start, nameof(StartKeyboardText) },
                { GameControl.Up, nameof(UpKeyboardText) },
                { GameControl.Down, nameof(DownKeyboardText) },
                { GameControl.Left, nameof(LeftKeyboardText) },
                { GameControl.Right, nameof(RightKeyboardText) },
            };

            Dictionary<GameControl, string> gamepadpropertiesToUpdate = new Dictionary<GameControl, string>()
            {
                { GameControl.Ok, nameof(OkControllerText) },
                { GameControl.Cancel, nameof(CancelControllerText) },
                { GameControl.Menu, nameof(MenuControllerText) },
                { GameControl.Switch, nameof(SwitchControllerText) },
                { GameControl.Pageup, nameof(PageUpControllerText) },
                { GameControl.Pagedown, nameof(PageDownControllerText) },
                { GameControl.Camera, nameof(CameraControllerText) },
                { GameControl.Target, nameof(TargetControllerText) },
                { GameControl.Assist, nameof(AssistControllerText) },
                { GameControl.Start, nameof(StartControllerText) },
                { GameControl.Up, nameof(UpControllerText) },
                { GameControl.Down, nameof(DownControllerText) },
                { GameControl.Left, nameof(LeftControllerText) },
                { GameControl.Right, nameof(RightControllerText) },
            };

            // use reflection to set the correct property based on the control that was updated

            PropertyInfo prop = this.GetType().GetProperty(propertiesToUpdate[controlToUpdate], BindingFlags.Public | BindingFlags.Instance);
            if (prop?.CanWrite == true && LoadedConfiguration.KeyboardInputs.ContainsKey(controlToUpdate))
            {
                prop.SetValue(this, LoadedConfiguration.KeyboardInputs[controlToUpdate]?.DisplayText, null);
            }

            prop = this.GetType().GetProperty(gamepadpropertiesToUpdate[controlToUpdate], BindingFlags.Public | BindingFlags.Instance);
            if (prop?.CanWrite == true && LoadedConfiguration.GamepadInputs.ContainsKey(controlToUpdate))
            {
                prop.SetValue(this, LoadedConfiguration.GamepadInputs[controlToUpdate]?.DisplayText, null);
            }

        }

        internal void StartCapturingKeyboardInput(GameControl controlToCapture)
        {
            IsCapturing = true;
            _controlToCapture = controlToCapture;
            _captureState = CaptureState.CaptureKeyboard;
        }

        internal void StartCapturingControllerInput(GameControl controlToCapture)
        {
            IsCapturing = true;
            _controlToCapture = controlToCapture;
            _captureState = CaptureState.CaptureController;
            PollForGamePadInput();
        }

        private Task PollForGamePadInput()
        {
            return Task.Factory.StartNew(() =>
            {
                while (IsCapturing && _captureState == CaptureState.CaptureController)
                {
                    GamePadState state = GamePad.GetState(PlayerIndex.One);

                    if (!state.IsConnected)
                    {
                        Thread.Sleep(100);
                        continue;
                    }

                    GamePadButton? pressedButton = GetPressedButton(state);

                    if (pressedButton.HasValue)
                    {
                        App.Current.Dispatcher.Invoke(() =>
                        {
                            SetControlIfCapturing(pressedButton.Value);
                        });

                        break;
                    }
                }

            });
        }

        private GamePadButton? GetPressedButton(GamePadState state)
        {
            if (state.Buttons.A == ButtonState.Pressed)
            {
                return GamePadButton.Button1;
            }
            else if (state.Buttons.B == ButtonState.Pressed)
            {
                return GamePadButton.Button2;
            }
            else if (state.Buttons.X == ButtonState.Pressed)
            {
                return GamePadButton.Button3;
            }
            else if (state.Buttons.Y == ButtonState.Pressed)
            {
                return GamePadButton.Button4;
            }
            else if (state.Buttons.LeftShoulder == ButtonState.Pressed)
            {
                return GamePadButton.Button5;
            }
            else if (state.Buttons.RightShoulder == ButtonState.Pressed)
            {
                return GamePadButton.Button6;
            }
            else if (state.Buttons.LeftStick == ButtonState.Pressed)
            {
                return GamePadButton.Button9;
            }
            else if (state.Buttons.RightStick == ButtonState.Pressed)
            {
                return GamePadButton.Button10;
            }
            else if (state.Buttons.Start == ButtonState.Pressed)
            {
                return GamePadButton.Button7;
            }
            else if (state.Buttons.Back == ButtonState.Pressed)
            {
                return GamePadButton.Button8;
            }
            
            // check dpad
            if (state.DPad.Up == ButtonState.Pressed)
            {
                return GamePadButton.DPadUp;
            }
            else if (state.DPad.Down == ButtonState.Pressed)
            {
                return GamePadButton.DPadDown;
            }
            else if (state.DPad.Left == ButtonState.Pressed)
            {
                return GamePadButton.DPadLeft;
            }
            else if (state.DPad.Right == ButtonState.Pressed)
            {
                return GamePadButton.DPadRight;
            }

            // check joystick for input
            if (state.ThumbSticks.Left.X > 0)
            {
                return GamePadButton.Right;
            }
            else if (state.ThumbSticks.Left.X < 0)
            {
                return GamePadButton.Left;
            }
            else if (state.ThumbSticks.Left.Y > 0)
            {
                return GamePadButton.Up;
            }
            else if (state.ThumbSticks.Left.Y < 0)
            {
                return GamePadButton.Down;
            }

            // check triggers
            if (state.Triggers.Left > 0)
            {
                return GamePadButton.LeftTrigger;
            }
            else if (state.Triggers.Right > 0)
            {
                return GamePadButton.RightTrigger;
            }

            return null;
        }

        internal void SaveNewCustomControl()
        {
            bool isValid = true;
            string title = ResourceHelper.Get(StringKey.SaveControlConfiguration);
            string prompt = "You must save the current controls as a new configuration. Enter name for configuration:";
            string controlName;
            string pathToFile;

            do
            {
                isValid = true;
                InputTextWindow inputBox = new InputTextWindow(title, prompt);
                inputBox.ViewModel.MaxCharLength = 24;

                bool? dialogResult = inputBox.ShowDialog();
                if (!dialogResult.GetValueOrDefault(false))
                {
                    return;
                }

                controlName = inputBox.ViewModel.TextInput;

                if (string.IsNullOrEmpty(controlName))
                {
                    isValid = false;
                    MessageDialogWindow.Show(ResourceHelper.Get(StringKey.ControlNameIsEmpty), ResourceHelper.Get(StringKey.SaveError), MessageBoxButton.OK, MessageBoxImage.Error);
                    continue;
                }

                if (Path.GetInvalidFileNameChars().Any(c => controlName.Contains(c)))
                {
                    isValid = false;
                    MessageDialogWindow.Show(ResourceHelper.Get(StringKey.ControlNameContainsInvalidChars), ResourceHelper.Get(StringKey.SaveError), MessageBoxButton.OK, MessageBoxImage.Error);
                    continue;
                }

                // construct path and check if already exists if name is valid
                if (isValid)
                {
                    if (controlName.EndsWith(".cfg"))
                    {
                        controlName = controlName.Substring(0, controlName.Length - 4);
                    }

                    pathToFile = Path.Combine(Sys.PathToControlsFolder, $"{controlName}.cfg");

                    if (File.Exists(pathToFile))
                    {
                        isValid = false;
                        MessageDialogWindow.Show(ResourceHelper.Get(StringKey.ControlsWithThatNameAlreadyExist), ResourceHelper.Get(StringKey.SaveError), MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            } while (!isValid);

            try
            {
                string pathToDefaultFile = Path.Combine(Sys.PathToControlsFolder, InGameConfigurationMap[_defaultControlNames[0]]);

                ControlMapper.CopyConfigurationFileAndSaveAsNew(pathToDefaultFile, $"{controlName}.cfg", LoadedConfiguration);
                
                InitInGameConfigOptions();
                SelectedGameConfigOption = controlName;
                //StatusMessage = ResourceHelper.Get(StringKey.SuccessfullyCreatedCustomControls);

            }
            catch (Exception e)
            {
                Logger.Error(e);
                //StatusMessage = $"{ResourceHelper.Get(StringKey.FailedToCreateCustomControls)}: {e.Message}";
            }
        }

        internal void DeleteSelectedCustomControl()
        {
            if (!IsCustomConfigOptionSelected)
            {
                return;
            }

            string fileName = $"{SelectedGameConfigOption}.cfg";
            string pathToFile = Path.Combine(Sys.PathToControlsFolder, fileName);

            if (!File.Exists(pathToFile))
            {
                Logger.Warn($"Can not delete custom contols: no file found at {pathToFile}");
                return;
            }

            try
            {
                File.Delete(pathToFile);
                InitInGameConfigOptions();
                SelectedGameConfigOption = InGameConfigOptions[0];
                //StatusMessage = $"{ResourceHelper.Get(StringKey.SuccessfullyDeletedCustomControls)} {fileName}.";
            }
            catch (Exception e)
            {
                Logger.Error(e);
                //StatusMessage = $"{ResourceHelper.Get(StringKey.FailedToDeleteCustomControls)}: {e.Message}";
            }
        }

        /// <summary>
        /// Copies ff7input.cfg from FF7 game folder to ./Resources/Controls/ folder with the given <paramref name="customFileName"/>
        /// </summary>
        /// <param name="forceCopy"> copies ff7input.cfg if it already exists; overwriting the current custom.cfg </param>
        public bool CopyInputCfgToCustomCfg(bool forceCopy, string customFileName)
        {
            string pathToCustomCfg = Path.Combine(Sys.PathToControlsFolder, customFileName);
            string pathToInputCfg = Path.Combine(Path.GetDirectoryName(Sys.Settings.FF7Exe), "ff7input.cfg");

            Directory.CreateDirectory(Sys.PathToControlsFolder);

            if (!File.Exists(pathToCustomCfg) || forceCopy)
            {
                if (File.Exists(pathToInputCfg))
                {
                    try
                    {
                        File.Copy(pathToInputCfg, pathToCustomCfg, true);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex);
                        //StatusMessage = $"{ResourceHelper.Get(StringKey.ErrorCopyingFf7InputCfg)} {ex.Message}";
                    }
                }
                else
                {
                    //StatusMessage = $"{ResourceHelper.Get(StringKey.NoFf7InputCfgFoundAt)} {pathToInputCfg}";
                    //Logger.Warn(StatusMessage);
                }
            }
            else
            {
                //StatusMessage = $"{customFileName} {ResourceHelper.Get(StringKey.AlreadyExistsAt)} {Sys.PathToControlsFolder}";
                //Logger.Warn(StatusMessage);
            }

            return false;
        }

        internal void SaveChangesToFile()
        {
            try
            {
                ControlMapper.SaveConfigurationToFile(Path.Combine(Sys.PathToControlsFolder, InGameConfigurationMap[SelectedGameConfigOption]), LoadedConfiguration);
                HasUnsavedChanges = false;
            }
            catch (Exception e)
            {
                Logger.Error(e);
                //StatusMessage = $"{ResourceHelper.Get(StringKey.FailedToDeleteCustomControls)}: {e.Message}";
            }
        }
    }
}

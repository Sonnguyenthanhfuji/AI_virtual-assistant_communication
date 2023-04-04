using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using System;

namespace TextSpeech
{
    public class TextToSpeech : MonoBehaviour
    {
        #region Init
        static TextToSpeech _instance;
        bool flag_learnStart = false;
        string[] Save1, Save2;
        string Next12 = "1";
        //array

        public static TextToSpeech instance
        {
            get
            {
                if (_instance == null)
                {
                    Init();
                }
                return _instance;
            }
        }
        public static void Init()
        {
            if (instance != null) return;
            GameObject obj = new GameObject();
            obj.name = "TextToSpeech";
            _instance = obj.AddComponent<TextToSpeech>();
        }
        void Awake()
        {
            _instance = this;
        }
        #endregion

        public Action onStartCallBack;
        public Action onDoneCallback;
        public Action<string> onSpeakRangeCallback;

        [Range(0.5f, 2)]
        public float pitch = 1f; //[0.5 - 2] Default 1
        [Range(0.5f, 2)]
        public float rate = 1f; //[min - max] android:[0.5 - 2] iOS:[0 - 1]

        public void Setting(string language, float _pitch, float _rate)
        {
            pitch = _pitch;
            rate = _rate;
#if UNITY_EDITOR
#elif UNITY_IPHONE
        _TAG_SettingSpeak(language, pitch, rate / 2);
#elif UNITY_ANDROID
        AndroidJavaClass javaUnityClass = new AndroidJavaClass("com.starseed.speechtotext.Bridge");
        javaUnityClass.CallStatic("SettingTextToSpeed", language, pitch, rate);
#endif
        }
        public void StartSpeak(string _message)
        {
            //hoc tap

            for(int i =0; i< Save1.Length-1; i++)
            if((_message == Save1[i]))
            {
                _message = Save2[i];
            }else


            if (flag_learnStart == true){
                if (Next12 == "1")
                {
                    Save1[Save1.Length] = _message;
                    Next12 = "2";
                }
                else if (Next12 == "2")
                {
                    Save2[Save2.Length] = _message;
                    Next12 = "1";
                    flag_learnStart = false;
                }
            } else
            if ((_message == "Học tập em nhé") || (_message == "Bây giờ học tập em nhé") || 
            (_message == "Bây giờ học nhé") || (_message == "Học tập nhé") || (_message == "Học nhé"))
            {
                _message = "Vâng";
                //luu bien flag_learnStart = true


            } else

            //------------------------------------
            if ((_message == "Nhắc lại nào")|| (_message == "Nhắc lại"))
            {
                _message = Save2[Save2.Length-1];
            }
            else
            //--------------------------------------------------------------
            if (_message == "hello")
            {
                _message = "hello you";
            }
            else
            if (_message == "Anh yêu em")
            {
                _message = "em cũng yêu anh";
            }
            else
            if (_message == "anh yêu em")
            {
                _message = "em yêu anh";
            }
            else
            if (_message == "i love you")
            {
                _message = "i love you too";
            }
            else
            if (_message == "I love you")
            {
                _message = "i love you too";
            }
            else

            if (_message == "xin chào")
            {
                _message = "xin chào Sơn";
            }
            else
            if (_message == "hi")
            {
                _message = "hello Son";
            }
            else
            if (_message == "what your name")
            {
                _message = "i am AI";
            }
            else
            if (_message == "how are you")
            {
                _message = "i am fine, thank you";
            }
            else
            if (_message == "what time is it")
            {
                _message = "The time is " + DateTime.Now.Hour.ToString();
            }
            else
            if (_message == "what time now")
            {
                _message = "The time is " + DateTime.Now.Hour.ToString();
            }
            else
            if (_message == "time")
            {
                _message = "The time is " + DateTime.Now.Hour.ToString() + " hour, " + DateTime.Now.Minute.ToString() + " minute ";
            }
            else
            if (_message == "what date time")
            {
                _message = "The date is " + DateTime.Now.DayOfWeek.ToString();
            }
            else
            if (_message == "what date now")
            {
                _message = "The date is " + DateTime.Now.DayOfWeek.ToString();
            }
            else
            if (_message == "date now")
            {
                _message = "The date is " + DateTime.Now.DayOfWeek.ToString();
            }
            else
            if (_message == "date")
            {
                _message = "The date is " + DateTime.Now.DayOfWeek.ToString();
            }
            else
            if (_message == "Hello")
            {
                _message = "hello you";
            }
            else
            if (_message == "Xin chào")
            {
                _message = "xin chào Sơn";
            }
            else
            if (_message == "Hi")
            {
                _message = "hello Son";
            }
            else
            if (_message == "What your name")
            {
                _message = "i am AI";
            }
            else
            if(_message == "How are you")
            {
                _message = "i am fine, thank you";
            }
            else
            if (_message == "What time is it")
            {
                _message = "The time is " + DateTime.Now.Hour.ToString();
            }
            else
            if (_message == "What time now")
            {
                _message = "The time is " + DateTime.Now.Hour.ToString();
            }
            else
            if (_message == "Time")
            {
                _message = "The time is " + DateTime.Now.Hour.ToString() +" hour, " + DateTime.Now.Minute.ToString() + " minute ";
            }
            else
            if (_message == "What date time")
            {
                _message = "The time is " + DateTime.Now.DayOfWeek.ToString();
            }
            else
            if (_message == "What date now")
            {
                _message = "The time is " + DateTime.Now.DayOfWeek.ToString();
            }
            else
            if (_message == "Date now")
            {
                _message = "The date is " + DateTime.Now.DayOfWeek.ToString();
            }
            else
            if (_message == "Date")
            {
                _message = "The date is " + DateTime.Now.DayOfWeek.ToString();
            }
            else

            if (_message == "Bạn khoẻ không")  //
            {
                _message = "Tôi khoẻ, còn bạn";
            }
            else
            if (_message == "Bạn sinh năm bao nhiêu")
            {
                _message = "Tôi sinh năm 2021";
            }
            else
                if (_message == "Bạn sinh năm mấy")
            {
                _message = "Tôi sinh năm 2021";
            }
            if (_message == "bạn khoẻ không")  //
            {
                _message = "Tôi khoẻ, còn bạn";
            }
            else
            if (_message == "bạn sinh năm bao nhiêu")
            {
                _message = "Tôi sinh năm 2021";
            }
            else
                if (_message == "bạn sinh năm mấy")
            {
                _message = "Tôi sinh năm 2021";
            }

            else
            if (_message == "Bây giờ là mấy giờ")     
            {
                _message = "Bây giờ là " + DateTime.Now.Hour.ToString() + " giờ, " + DateTime.Now.Minute.ToString() + " phút ";
            }
            else
            if (_message == "Giờ")
            {
                _message = "Bây giờ là " + DateTime.Now.Hour.ToString() + " giờ, " + DateTime.Now.Minute.ToString() + " phút ";
            }
            else
            if (_message == "What year")
            {
                _message = "The year is " + DateTime.Now.Year.ToString();
            }
            else
            if (_message == "year")
            {
                _message = "The year is " + DateTime.Now.Year.ToString();
            }
            if (_message == "Year")
            {
                _message = "The year is " + DateTime.Now.Year.ToString();
            }
            else
            if (_message == "What year now")
            {
                _message = "The year is " + DateTime.Now.Year.ToString();
            }
            else
            if (_message == "Hôm nay là thứ mấy")
            {
                _message = "Hôm nay là thứ " + DateTime.Now.DayOfWeek.ToString();
            }
            else
            if (_message == "Hôm nay là ngày mấy")
            {
                _message = "Hôm nay là ngày " + DateTime.Now.TimeOfDay.ToString();
            }
            else
            if (_message == "Năm nay là năm mấy")
            {
                _message = "Năm nay là năm " + DateTime.Now.Year.ToString();
            }

            else
            if (_message == "bây giờ là mấy giờ")
            {
                _message = "Bây giờ là " + DateTime.Now.Hour.ToString() + " giờ, " + DateTime.Now.Minute.ToString() + " phút ";
            }
            else
            if (_message == "giờ")
            {
                _message = "Bây giờ là " + DateTime.Now.Hour.ToString() + " giờ, " + DateTime.Now.Minute.ToString() + " phút ";
            }
            else
            if (_message == "what year")
            {
                _message = "The year is " + DateTime.Now.Year.ToString();
            }
            else
            if (_message == "what year now")
            {
                _message = "The year is " + DateTime.Now.Year.ToString();
            }
            else
            if (_message == "hôm nay là thứ mấy")
            {
                _message = "Hôm nay là thứ " + DateTime.Now.DayOfWeek.ToString();
            }
            else
            if (_message == "hôm nay là ngày mấy")
            {
                _message = "Hôm nay là ngày " + DateTime.Now.TimeOfDay.ToString();
            }
            else
            if (_message == "năm nay là năm mấy")
            {
                _message = "Năm nay là năm " + DateTime.Now.Year.ToString();
            }




#if UNITY_EDITOR
#elif UNITY_IPHONE
        _TAG_StartSpeak(_message);
#elif UNITY_ANDROID
        AndroidJavaClass javaUnityClass = new AndroidJavaClass("com.starseed.speechtotext.Bridge");
        javaUnityClass.CallStatic("OpenTextToSpeed", _message);

#endif
        }
        public void StopSpeak()
        {
#if UNITY_EDITOR
#elif UNITY_IPHONE
        _TAG_StopSpeak();
#elif UNITY_ANDROID
        AndroidJavaClass javaUnityClass = new AndroidJavaClass("com.starseed.speechtotext.Bridge");
        javaUnityClass.CallStatic("StopTextToSpeed");
#endif
        }

        public void onSpeechRange(string _message)
        {
            if (onSpeakRangeCallback != null && _message != null)
            {
                onSpeakRangeCallback(_message);
            }
        }
        public void onStart(string _message)
        {
            if (onStartCallBack != null)
                onStartCallBack();
        }
        public void onDone(string _message)
        {
            if (onDoneCallback != null)
                onDoneCallback();
        }
        public void onError(string _message)
        {
        }
        public void onMessage(string _message)
        {

        }
        /** Denotes the language is available for the language by the locale, but not the country and variant. */
        public const int LANG_AVAILABLE = 0;
        /** Denotes the language data is missing. */
        public const int LANG_MISSING_DATA = -1;
        /** Denotes the language is not supported. */
        public const int LANG_NOT_SUPPORTED = -2;
        public void onSettingResult(string _params)
        {
            int _error = int.Parse(_params);
            string _message = "";
            if (_error == LANG_MISSING_DATA || _error == LANG_NOT_SUPPORTED)
            {
                _message = "This Language is not supported";
            }
            else
            {
                _message = "This Language valid";
            }
            Debug.Log(_message);
        }

#if UNITY_IPHONE
        [DllImport("__Internal")]
        private static extern void _TAG_StartSpeak(string _message);

        [DllImport("__Internal")]
        private static extern void _TAG_SettingSpeak(string _language, float _pitch, float _rate);

        [DllImport("__Internal")]
        private static extern void _TAG_StopSpeak();
#endif
    }
}

using XeSys;

namespace XeApp.Game.AR
{
    public enum SelMsgID
    {
        AT_CAMERA = 0,
        AT_STORAGE = 1,
        AT_SHUTDOWN = 2,
    }

    public enum MessageID
    {
        NONE = -1,
        SAVED_PHOTO = 0,
        ERR_CAMERA_PERMISSION = 1,
        ERR_DEVICE_NOT_SUPPORTED = 2,
        ERR_VUFORIA_INIT_ERROR = 3,
        ERR_NO_PERMISSION_STORAGE = 4,
        ERR_NOT_ABAILABLE_STORAGE = 5,
        ERR_NO_SPACE_FOR_DATASET = 6,
        ERR_NO_SYSTEM_ERROR = 7,
        NUM = 8,
    }

    public class Messages
    {
        private static readonly string[] MESSAGE_LABEL_TABLE = new string[8]
        {
            "ar_popup_saved_photo",
            "ar_popup_err_camera_permission",
            "ar_popup_err_device_not_supported",
            "ar_popup_err_vuforia_init_error",
            "ar_popup_err_no_permission_storage",
            "ar_popup_err_not_abailable_storage",
            "ar_popup_err_no_space_for_dataset",
            "ar_popup_err_no_system_error"
        }; // 0x0

        // // RVA: 0x13AD7E4 Offset: 0x13AD7E4 VA: 0x13AD7E4
        public static string Get(MessageID msgId)
        {
            MessageBank bk = MessageManager.Instance.GetBank("menu");
            if((int)msgId < 0 || (int)msgId > 7)
                return "";
            return bk.GetMessageByLabel(MESSAGE_LABEL_TABLE[(int)msgId]);
        }

        // RVA: 0x13A91CC Offset: 0x13A91CC VA: 0x13A91CC
        public static string[] GetSel(SelMsgID msgId, bool cameraPermission, bool storagePermission)
        {
            string[] res = new string[3];
            MessageBank bk = MessageManager.Instance.GetBank("menu");
            if(msgId == SelMsgID.AT_SHUTDOWN)
            {
                res[0] = bk.GetMessageByLabel("ar_sel_popup_shutdown_message");
                res[1] = bk.GetMessageByLabel("ar_sel_popup_shutdown_button_l");
                res[2] = bk.GetMessageByLabel("ar_sel_popup_shutdown_button_r");
            }
            else if(msgId == SelMsgID.AT_STORAGE)
            {
                res[0] = bk.GetMessageByLabel("ar_sel_popup_storage_message_android");
                res[1] = bk.GetMessageByLabel("ar_sel_popup_storage_button_l");
                res[2] = bk.GetMessageByLabel("ar_sel_popup_storage_button_r");
            }
            else if(msgId == SelMsgID.AT_CAMERA)
            {
                res[0] = bk.GetMessageByLabel("ar_sel_popup_camera_message");
                res[1] = bk.GetMessageByLabel("ar_sel_popup_camera_button_l");
                res[2] = bk.GetMessageByLabel("ar_sel_popup_camera_button_r");
            }
            bool b = false;
            if(!cameraPermission)
            {
                res[0] += bk.GetMessageByLabel("ar_sel_popup_camera_text");
                b = true;
            }
            if(!storagePermission)
            {
                if(b)
                {
                    res[0] += "\n";
                }
                res[0] += bk.GetMessageByLabel("ar_sel_popup_storage_text_android");
            }
            return res;
        }
    }
}
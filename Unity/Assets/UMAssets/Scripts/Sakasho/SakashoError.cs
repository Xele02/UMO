
using Sakasho.JSON;
using System.Collections;

public class SakashoError
{
	public const string ERROR_401 = "SESSION_NOT_FOUND";
	public const string ERROR_500 = "INTERNAL_SERVER_ERROR";
	public const string ERROR_600 = "INTERNAL_CLIENT_ERROR";
	public const string ERROR_601 = "LOGIC_ERROR";
	public const string ERROR_602 = "ILLEGAL_ARGUMENT";
	public const string ERROR_603 = "NETWORK_ERROR";
	public const string ERROR_604 = "UNSUPPORTED_API_CALLED";
	public const string ERROR_605 = "PLAYER_SESSION_CLOSED";
	public const string ERROR_606 = "LOGOUT_CANCELLED";
	public const string ERROR_1001 = "PURCHASING_FAILED";
	public const string ERROR_1101 = "LOGIN_CANCELLED";

	public int ResponseCode { get; private set; } // 0x8
	public string ErrorCode { get; private set; } // 0xC
	public string ErrorDetailJSON { get; private set; } // 0x10
	public string ResponseBodyJSON { get; private set; } // 0x14

	// // RVA: 0x307A048 Offset: 0x307A048 VA: 0x307A048
	public SakashoError(int responseCode, string responseBodyJSON)
    {
		ResponseBodyJSON = responseBodyJSON;
		ResponseCode = responseCode;
		Hashtable h = MiniJSON.jsonDecode(responseBodyJSON) as Hashtable;
		bool isEmpty = false;
		if (h == null)
		{
			h = new Hashtable();
			isEmpty = true;
		}
		string errorType = "INTERNAL_SERVER_ERROR";
		if (responseCode == 401)
			errorType = "SESSION_NOT_FOUND";
		if (responseCode == 600)
			errorType = "INTERNAL_CLIENT_ERROR";
		string s = h["error_code"] as string;
		if (s != null)
			errorType = s;
		ErrorCode = errorType;
		h = h["error_detail"] as Hashtable;
		if (h != null)
		{
			ErrorDetailJSON = MiniJSON.jsonEncode(h);
			if (!isEmpty)
				return;
		}
		else if (isEmpty)
		{
			h = new Hashtable();
			h["message"] = responseBodyJSON;
			ErrorDetailJSON = MiniJSON.jsonEncode(h);
		}
		else
			return;
		Hashtable h3 = new Hashtable();
		h3["error_code"] = ErrorCode;
		h3["error_detail"] = h;
		ResponseBodyJSON = MiniJSON.jsonEncode(h3);
	}

	// // RVA: 0x307A424 Offset: 0x307A424 VA: 0x307A424
	public SakashoErrorId getErrorId()
	{
		if(ErrorCode == "INTERNAL_SERVER_ERROR")
			return SakashoErrorId.INTERNAL_SERVER_ERROR;
		if(ErrorCode == "NETWORK_ERROR")
			return SakashoErrorId.NETWORK_ERROR;
		if(ErrorCode == "INTERNAL_CLIENT_ERROR")
			return SakashoErrorId.INTERNAL_CLIENT_ERROR;
		if(ErrorCode == "UNSUPPORTED_API_CALLED")
			return SakashoErrorId.UNSUPPORTED_API_CALLED;
		if(ErrorCode == "MASTER_DATA_NOT_FOUND")
			return SakashoErrorId.MASTER_DATA_NOT_FOUND;
		if(ErrorCode == "MASTER_SINGLE_DATA_NOT_FOUND")
			return SakashoErrorId.MASTER_SINGLE_DATA_NOT_FOUND;
		if(ErrorCode == "ILLEGAL_ARGUMENT")
			return SakashoErrorId.ILLEGAL_ARGUMENT;
		if(ErrorCode == "MASTER_DATA_IDS_NOT_FOUND")
			return SakashoErrorId.MASTER_DATA_IDS_NOT_FOUND;
		if(ErrorCode == "REQUEST_PARAMETER_NOT_ALLOWED")
			return SakashoErrorId.REQUEST_PARAMETER_NOT_ALLOWED;
		if(ErrorCode == "INFORMATION_NOT_FOUND")
			return SakashoErrorId.INFORMATION_NOT_FOUND;
		if(ErrorCode == "LOT_REST_COUNT_NOT_ENOUGH")
			return SakashoErrorId.LOT_REST_COUNT_NOT_ENOUGH;
		if(ErrorCode == "REQUEST_TRANSACTION_NOT_ALLOWED")
			return SakashoErrorId.REQUEST_TRANSACTION_NOT_ALLOWED;
		if(ErrorCode == "PRODUCT_NOT_FOUND")
			return SakashoErrorId.PRODUCT_NOT_FOUND;
		if(ErrorCode == "PRODUCT_REST_QUANTITY_NOT_ENOUGH")
			return SakashoErrorId.PRODUCT_REST_QUANTITY_NOT_ENOUGH;
		if(ErrorCode == "PURCHASING_FAILED")
			return SakashoErrorId.PURCHASING_FAILED;
		if(ErrorCode == "LOT_PRODUCT_NOT_FOUND")
			return SakashoErrorId.LOT_PRODUCT_NOT_FOUND;
		if(ErrorCode == "REQUEST_ROUND_NOT_ALLOWED")
			return SakashoErrorId.REQUEST_ROUND_NOT_ALLOWED;
		if(ErrorCode == "PLAYER_BOX_ALREADY_MAX_ROUND")
			return SakashoErrorId.PLAYER_BOX_ALREADY_MAX_ROUND;
		if(ErrorCode == "PLAYER_BOX_NOT_UPGRADABLE")
			return SakashoErrorId.PLAYER_BOX_NOT_UPGRADABLE;
		if(ErrorCode == "PLAYER_BOX_NOT_FOUND")
			return SakashoErrorId.PLAYER_BOX_NOT_FOUND;
		if(ErrorCode == "SERIAL_CODE_ALREADY_USED")
			return SakashoErrorId.SERIAL_CODE_ALREADY_USED;
		if(ErrorCode == "SERIAL_CODE_ALREADY_USED_BY_SOMEONE")
			return SakashoErrorId.SERIAL_CODE_ALREADY_USED_BY_SOMEONE;
		if(ErrorCode == "SERIAL_CODE_NOT_FOUND")
			return SakashoErrorId.SERIAL_CODE_NOT_FOUND;
		if(ErrorCode == "SERIAL_CODE_GROUP_REQUIRED")
			return SakashoErrorId.SERIAL_CODE_GROUP_REQUIRED;
		if(ErrorCode == "PLAYER_TOKEN_CHECK_FAILED")
			return SakashoErrorId.PLAYER_TOKEN_CHECK_FAILED;
		if(ErrorCode == "PLAYER_INCLUDED_NG_WORDS")
			return SakashoErrorId.PLAYER_INCLUDED_NG_WORDS;
		if(ErrorCode == "PLAYER_VALIDATION_FAILED")
			return SakashoErrorId.PLAYER_VALIDATION_FAILED;
		if(ErrorCode == "INVENTORY_NOT_FOUND")
			return SakashoErrorId.INVENTORY_NOT_FOUND;
		if(ErrorCode == "PLAYER_UPDATED_AT_CHECK_FAILED")
			return SakashoErrorId.PLAYER_UPDATED_AT_CHECK_FAILED;
		if(ErrorCode == "PLAYER_NOT_FOUND")
			return SakashoErrorId.PLAYER_NOT_FOUND;
		if(ErrorCode == "INVALID_SORT_TARGET")
			return SakashoErrorId.INVALID_SORT_TARGET;
		if(ErrorCode == "PLAYER_SEARCH_KEY_NOT_FOUND")
			return SakashoErrorId.PLAYER_SEARCH_KEY_NOT_FOUND;
		if(ErrorCode == "PLAYER_SEARCH_KEY_NOT_EXIST")
			return SakashoErrorId.PLAYER_SEARCH_KEY_NOT_EXIST;
		if(ErrorCode == "INVALID_DATA_TYPE")
			return SakashoErrorId.INVALID_DATA_TYPE;
		if(ErrorCode == "NOT_PERMITTED_NAMESPACES")
			return SakashoErrorId.NOT_PERMITTED_NAMESPACES;
		if(ErrorCode == "PLAYER_ID_NOT_FOUND")
			return SakashoErrorId.PLAYER_ID_NOT_FOUND;
		if(ErrorCode == "LIMIT_OVER_PLAYER_IDS")
			return SakashoErrorId.LIMIT_OVER_PLAYER_IDS;
		if(ErrorCode == "NORMAL_ITEM_INCLUDED")
			return SakashoErrorId.NORMAL_ITEM_INCLUDED;
		if(ErrorCode == "LIST_FILE_NOT_FOUND")
			return SakashoErrorId.LIST_FILE_NOT_FOUND;
		if(ErrorCode == "ASSET_NOT_FOUND")
			return SakashoErrorId.ASSET_NOT_FOUND;
		if(ErrorCode == "LOGIN_BONUS_NOT_FOUND")
			return SakashoErrorId.LOGIN_BONUS_NOT_FOUND;
		if(ErrorCode == "PLAYER_ALREADY_LOGINED")
			return SakashoErrorId.PLAYER_ALREADY_LOGINED;
		if(ErrorCode == "LOGIN_BONUS_ALREADY_RECEIVED")
			return SakashoErrorId.LOGIN_BONUS_ALREADY_RECEIVED;
		if(ErrorCode == "LOGIN_BONUS_FINISHED")
			return SakashoErrorId.LOGIN_BONUS_FINISHED;
		if(ErrorCode == "FRIEND_NOT_FOUND")
			return SakashoErrorId.FRIEND_NOT_FOUND;
		if(ErrorCode == "USE_FACEBOOK_FORCE_FRIEND")
			return SakashoErrorId.USE_FACEBOOK_FORCE_FRIEND;
		if(ErrorCode == "FRIEND_REQUEST_FORBIDDEN")
			return SakashoErrorId.FRIEND_REQUEST_FORBIDDEN;
		if(ErrorCode == "ALREADY_BECOME_FRIEND")
			return SakashoErrorId.ALREADY_BECOME_FRIEND;
		if(ErrorCode == "ALREADY_RECEIVED_FRIEND_REQUEST")
			return SakashoErrorId.ALREADY_RECEIVED_FRIEND_REQUEST;
		if(ErrorCode == "ALREADY_BLOCKED_FRIEND_REQUEST")
			return SakashoErrorId.ALREADY_BLOCKED_FRIEND_REQUEST;
		if(ErrorCode == "ALREADY_SENT_FRIEND_REQUEST")
			return SakashoErrorId.ALREADY_SENT_FRIEND_REQUEST;
		if(ErrorCode == "TARGET_PLAYER_FRIEND_LIMIT_EXCEEDED")
			return SakashoErrorId.TARGET_PLAYER_FRIEND_LIMIT_EXCEEDED;
		if(ErrorCode == "FRIEND_REQUEST_NOT_FOUND")
			return SakashoErrorId.FRIEND_REQUEST_NOT_FOUND;
		if(ErrorCode == "FRIEND_LIMIT_EXCEEDED")
			return SakashoErrorId.FRIEND_LIMIT_EXCEEDED;
		if(ErrorCode == "REQUEST_BODY_NOT_ALLOWED")
			return SakashoErrorId.REQUEST_BODY_NOT_ALLOWED;
		if(ErrorCode == "CANNOT_LOWER_FRIENDS_LIMIT")
			return SakashoErrorId.CANNOT_LOWER_FRIENDS_LIMIT;
		if(ErrorCode == "SYSTEM_FRIENDS_LIMIT_EXCEEDED")
			return SakashoErrorId.SYSTEM_FRIENDS_LIMIT_EXCEEDED;
		if(ErrorCode == "DONT_SEND_SELF_MESSAGE_QUEUE")
			return SakashoErrorId.DONT_SEND_SELF_MESSAGE_QUEUE;
		if(ErrorCode == "DUPLICATE_PLAYER_ID")
			return SakashoErrorId.DUPLICATE_PLAYER_ID;
		if(ErrorCode == "MESSAGE_JSON_PARSE_ERROR")
			return SakashoErrorId.MESSAGE_JSON_PARSE_ERROR;
		if(ErrorCode == "OVER_EXPIRED_VALUE")
			return SakashoErrorId.OVER_EXPIRED_VALUE;
		if(ErrorCode == "PLAYER_DATA_JSON_PARSE_ERROR")
			return SakashoErrorId.PLAYER_DATA_JSON_PARSE_ERROR;
		if(ErrorCode == "MESSAGE_QUEUE_NOT_FOUND")
			return SakashoErrorId.MESSAGE_QUEUE_NOT_FOUND;
		if(ErrorCode == "GAME_NOT_FACEBOOK_LINKAGE")
			return SakashoErrorId.GAME_NOT_FACEBOOK_LINKAGE;
		if(ErrorCode == "FACEBOOK_USER_ID_ALREADY_EXISTS")
			return SakashoErrorId.FACEBOOK_USER_ID_ALREADY_EXISTS;
		if(ErrorCode == "FACEBOOK_ACCESS_TOKEN_ERROR")
			return SakashoErrorId.FACEBOOK_ACCESS_TOKEN_ERROR;
		if(ErrorCode == "NO_MATCH_FACEBOOK_APPLICATION_ID")
			return SakashoErrorId.NO_MATCH_FACEBOOK_APPLICATION_ID;
		if(ErrorCode == "REQUEST_BODY_JSON_PARSE_ERROR")
			return SakashoErrorId.REQUEST_BODY_JSON_PARSE_ERROR;
		if(ErrorCode == "PLAYER_FACEBOOK_DATA_NOT_FOUND")
			return SakashoErrorId.PLAYER_FACEBOOK_DATA_NOT_FOUND;
		if(ErrorCode == "RANKING_CLOSED")
			return SakashoErrorId.RANKING_CLOSED;
		if(ErrorCode == "RANKING_NOT_FOUND")
			return SakashoErrorId.RANKING_NOT_FOUND;
		if(ErrorCode == "RANKING_NOT_OPEN")
			return SakashoErrorId.RANKING_NOT_OPEN;
		if(ErrorCode == "RANKING_NOT_GENERATED")
			return SakashoErrorId.RANKING_NOT_GENERATED;
		if(ErrorCode == "RANKING_PLAYER_NOT_FOUND")
			return SakashoErrorId.RANKING_PLAYER_NOT_FOUND;
		if(ErrorCode == "RANKING_SAVE_CLOSED")
			return SakashoErrorId.RANKING_SAVE_CLOSED;
		if(ErrorCode == "RANKING_NOT_REWARD_PERIOD")
			return SakashoErrorId.RANKING_NOT_REWARD_PERIOD;
		if(ErrorCode == "RANKING_REWARD_TAKEN")
			return SakashoErrorId.RANKING_REWARD_TAKEN;
		if(ErrorCode == "CATEGORY_NOT_FOUND")
			return SakashoErrorId.CATEGORY_NOT_FOUND;
		if(ErrorCode == "TARGET_NOT_FOUND")
			return SakashoErrorId.TARGET_NOT_FOUND;
		if(ErrorCode == "REGULAR_RANKING_NOT_GENERATED")
			return SakashoErrorId.REGULAR_RANKING_NOT_GENERATED;
		if(ErrorCode == "INVALID_PASSPHRASE")
			return SakashoErrorId.INVALID_PASSPHRASE;
		if(ErrorCode == "STORE_SERVER_ERROR")
			return SakashoErrorId.STORE_SERVER_ERROR;
		if(ErrorCode == "CANNOT_MAKE_PAYMENTS")
			return SakashoErrorId.CANNOT_MAKE_PAYMENTS;
		if(ErrorCode == "CURRENCY_ID_NOT_FOUND")
			return SakashoErrorId.CURRENCY_ID_NOT_FOUND;
		if(ErrorCode == "IAB_APP_PUBLIC_KEY_NOT_FOUND")
			return SakashoErrorId.IAB_APP_PUBLIC_KEY_NOT_FOUND;
		if(ErrorCode == "PRODUCT_TRANSACTION_EXISTS")
			return SakashoErrorId.PRODUCT_TRANSACTION_EXISTS;
		if(ErrorCode == "EXCEEDED_PRODUCT_QUANTITY_LIMIT")
			return SakashoErrorId.EXCEEDED_PRODUCT_QUANTITY_LIMIT;
		if(ErrorCode == "ANOTHER_PROCESS_IN_PROGRESS")
			return SakashoErrorId.ANOTHER_PROCESS_IN_PROGRESS;
		if(ErrorCode == "PLATFORM_RECEIPT_INVALID")
			return SakashoErrorId.PLATFORM_RECEIPT_INVALID;
		if(ErrorCode == "TRANSACTION_INVALID")
			return SakashoErrorId.TRANSACTION_INVALID;
		if(ErrorCode == "TRANSACTION_NOT_FOUND")
			return SakashoErrorId.TRANSACTION_NOT_FOUND;
		if(ErrorCode == "PLAYER_AGE_UNKNOWN")
			return SakashoErrorId.PLAYER_AGE_UNKNOWN;
		if(ErrorCode == "PLATFORM_PRODUCT_ID_NOT_REGISTERED")
			return SakashoErrorId.PLATFORM_PRODUCT_ID_NOT_REGISTERED;
		if(ErrorCode == "PURCHASING_CANCELLED")
			return SakashoErrorId.PURCHASING_CANCELLED;
		if(ErrorCode == "INSUFFICIENT_CURRENCY_QUANTITY")
			return SakashoErrorId.INSUFFICIENT_CURRENCY_QUANTITY;
		if(ErrorCode == "MONTHLY_TOTAL_AMOUNT_OVER")
			return SakashoErrorId.MONTHLY_TOTAL_AMOUNT_OVER;
		if(ErrorCode == "INSUFFICIENT_LOTS")
			return SakashoErrorId.INSUFFICIENT_LOTS;
		if(ErrorCode == "INVALID_PRODUCT")
			return SakashoErrorId.INVALID_PRODUCT;
		if(ErrorCode == "RECOVERY_ERROR")
			return SakashoErrorId.RECOVERY_ERROR;
		if(ErrorCode == "LOG_JSON_PARSE_ERROR")
			return SakashoErrorId.LOG_JSON_PARSE_ERROR;
		if(ErrorCode == "EXCEEDED_MAX_JSON_DATA_SIZE")
			return SakashoErrorId.EXCEEDED_MAX_JSON_DATA_SIZE;
		if(ErrorCode == "LABEL_NOT_FOUND")
			return SakashoErrorId.LABEL_NOT_FOUND;
		if(ErrorCode == "INVALID_TEMPLATE_NAME")
			return SakashoErrorId.INVALID_TEMPLATE_NAME;
		if(ErrorCode == "NOT_AVAILABLE_TEMPLATE")
			return SakashoErrorId.NOT_AVAILABLE_TEMPLATE;
		if(ErrorCode == "AMAZON_REQUEST_TIME_OUT")
			return SakashoErrorId.AMAZON_REQUEST_TIME_OUT;
		if(ErrorCode == "OS_SERVICE_DISABLED")
			return SakashoErrorId.OS_SERVICE_DISABLED;
		if(ErrorCode == "MAIL_NOT_FOUND")
			return SakashoErrorId.MAIL_NOT_FOUND;
		if(ErrorCode == "INCLUDED_NG_WORDS")
			return SakashoErrorId.INCLUDED_NG_WORDS;
		if(ErrorCode == "INVALID_JSON_DATA")
			return SakashoErrorId.INVALID_JSON_DATA;
		if(ErrorCode == "EXCEEDED_MAX_EVENT_ID_SIZE")
			return SakashoErrorId.EXCEEDED_MAX_EVENT_ID_SIZE;
		if(ErrorCode == "INVALID_EVENT_ID")
			return SakashoErrorId.INVALID_EVENT_ID;
		if(ErrorCode == "INVALID_BIRTHDAY")
			return SakashoErrorId.INVALID_BIRTHDAY;
		if(ErrorCode == "OLDER_REQUIREMENT_CLIENT_VERSION")
			return SakashoErrorId.OLDER_REQUIREMENT_CLIENT_VERSION;
		if(ErrorCode == "PLAYER_ALREADY_CREATED")
			return SakashoErrorId.PLAYER_ALREADY_CREATED;
		if(ErrorCode == "EXPIRED_PASSPHRASE")
			return SakashoErrorId.EXPIRED_PASSPHRASE;
		if(ErrorCode == "TRANSFER_LIMIT_EXCEEDED")
			return SakashoErrorId.TRANSFER_LIMIT_EXCEEDED;
		if(ErrorCode == "UNSUPPORTED_ITEM_SET_TYPE")
			return SakashoErrorId.UNSUPPORTED_ITEM_SET_TYPE;
		if(ErrorCode == "ITEM_SET_NOT_FOUND")
			return SakashoErrorId.ITEM_SET_NOT_FOUND;
		if(ErrorCode == "ANOTHER_FACEBOOK_USER_ID_ALREADY_EXISTS")
			return SakashoErrorId.ANOTHER_FACEBOOK_USER_ID_ALREADY_EXISTS;
		if(ErrorCode == "KEYS_EXPIRED")
			return SakashoErrorId.KEYS_EXPIRED;
		if(ErrorCode == "KEYS_NOT_FOUND")
			return SakashoErrorId.KEYS_NOT_FOUND;
		if(ErrorCode == "ACHIEVEMENT_PRIZE_ALREADY_RECEIVED")
			return SakashoErrorId.ACHIEVEMENT_PRIZE_ALREADY_RECEIVED;
		if(ErrorCode == "BODY_TOO_LONG")
			return SakashoErrorId.BODY_TOO_LONG;
		if(ErrorCode == "SUBJECT_TOO_LONG")
			return SakashoErrorId.SUBJECT_TOO_LONG;
		if(ErrorCode == "FORBIDDEN")
			return SakashoErrorId.FORBIDDEN;
		if(ErrorCode == "THREAD_NOT_FOUND")
			return SakashoErrorId.THREAD_NOT_FOUND;
		if(ErrorCode == "COMMENT_NOT_FOUND")
			return SakashoErrorId.COMMENT_NOT_FOUND;
		if(ErrorCode == "THREAD_READ_NOT_ALLOWED")
			return SakashoErrorId.THREAD_READ_NOT_ALLOWED;
		if(ErrorCode == "SORT_ORDER_INVALID")
			return SakashoErrorId.SORT_ORDER_INVALID;
		if(ErrorCode == "FILTER_BY_COMMENT_WRITER_ID_INVALID")
			return SakashoErrorId.FILTER_BY_COMMENT_WRITER_ID_INVALID;
		if(ErrorCode == "MARK_TYPE_INVALID")
			return SakashoErrorId.MARK_TYPE_INVALID;
		if(ErrorCode == "FILTER_OP_INVALID")
			return SakashoErrorId.FILTER_OP_INVALID;
		if(ErrorCode == "FILTER_BY_THREAD_OWNER_ID_INVALID")
			return SakashoErrorId.FILTER_BY_THREAD_OWNER_ID_INVALID;
		if(ErrorCode == "SORT_BY_INVALID")
			return SakashoErrorId.SORT_BY_INVALID;
		if(ErrorCode == "FILTER_BY_THREAD_GROUP_INVALID")
			return SakashoErrorId.FILTER_BY_THREAD_GROUP_INVALID;
		if(ErrorCode == "THREAD_GROUP_INVALID")
			return SakashoErrorId.THREAD_GROUP_INVALID;
		if(ErrorCode == "READ_PLAYER_IDS_INVALID")
			return SakashoErrorId.READ_PLAYER_IDS_INVALID;
		if(ErrorCode == "WRITE_PLAYER_IDS_INVALID")
			return SakashoErrorId.WRITE_PLAYER_IDS_INVALID;
		if(ErrorCode == "MAX_COMMENTS_INVALID")
			return SakashoErrorId.MAX_COMMENTS_INVALID;
		if(ErrorCode == "DETAIL_INVALID")
			return SakashoErrorId.DETAIL_INVALID;
		if(ErrorCode == "THREAD_SCORE_INVALID")
			return SakashoErrorId.THREAD_SCORE_INVALID;
		if(ErrorCode == "TITLE_INVALID")
			return SakashoErrorId.TITLE_INVALID;
		if(ErrorCode == "MIN_COMMENT_BYTES_INVALID")
			return SakashoErrorId.MIN_COMMENT_BYTES_INVALID;
		if(ErrorCode == "COMMENT_BYTES_LIMIT_CONFLICT")
			return SakashoErrorId.COMMENT_BYTES_LIMIT_CONFLICT;
		if(ErrorCode == "EXTRA_INVALID")
			return SakashoErrorId.EXTRA_INVALID;
		if(ErrorCode == "UPDATE_PLAYER_IDS_INVALID")
			return SakashoErrorId.UPDATE_PLAYER_IDS_INVALID;
		if(ErrorCode == "MAX_COMMENT_BYTES_INVALID")
			return SakashoErrorId.MAX_COMMENT_BYTES_INVALID;
		if(ErrorCode == "TITLE_REQUIRED")
			return SakashoErrorId.TITLE_REQUIRED;
		if(ErrorCode == "NG_WORD_INCLUDED")
			return SakashoErrorId.NG_WORD_INCLUDED;
		if(ErrorCode == "CONTENT_INVALID")
			return SakashoErrorId.CONTENT_INVALID;
		if(ErrorCode == "MAX_COMMENTS_EXCEEDED")
			return SakashoErrorId.MAX_COMMENTS_EXCEEDED;
		if(ErrorCode == "SAGE_INVALID")
			return SakashoErrorId.SAGE_INVALID;
		if(ErrorCode == "REPLY_TO_INVALID")
			return SakashoErrorId.REPLY_TO_INVALID;
		if(ErrorCode == "THREAD_WRITE_NOT_ALLOWED")
			return SakashoErrorId.THREAD_WRITE_NOT_ALLOWED;
		if(ErrorCode == "CONTENT_REQUIRED")
			return SakashoErrorId.CONTENT_REQUIRED;
		if(ErrorCode == "NICKNAME_INVALID")
			return SakashoErrorId.NICKNAME_INVALID;
		if(ErrorCode == "THREAD_UPDATE_NOT_ALLOWED")
			return SakashoErrorId.THREAD_UPDATE_NOT_ALLOWED;
		if(ErrorCode == "COMMENT_UPDATE_NOT_ALLOWED")
			return SakashoErrorId.COMMENT_UPDATE_NOT_ALLOWED;
		if(ErrorCode == "UNMARK_TYPE_INVALID")
			return SakashoErrorId.UNMARK_TYPE_INVALID;
		if(ErrorCode == "APPLICATION_UNDER_MAINTENANCE")
			return SakashoErrorId.APPLICATION_UNDER_MAINTENANCE;
		if(ErrorCode == "PLAYER_ACCOUNT_STATUS_IS_SERVER_ACCESS_DENY")
			return SakashoErrorId.PLAYER_ACCOUNT_STATUS_IS_SERVER_ACCESS_DENY;
		if(ErrorCode == "PLAYER_ACCOUNT_STATUS_IS_BBS_SERVER_ACCESS_DENY")
			return SakashoErrorId.PLAYER_ACCOUNT_STATUS_IS_BBS_SERVER_ACCESS_DENY;
		if(ErrorCode == "RANKING_REWARD_NOT_FOUND")
			return SakashoErrorId.RANKING_REWARD_NOT_FOUND;
		if(ErrorCode == "SESSION_NOT_FOUND")
			return SakashoErrorId.SESSION_NOT_FOUND;
		if(ErrorCode == "CODE_GROUP_NOT_FOUND")
			return SakashoErrorId.CODE_GROUP_NOT_FOUND;
		if(ErrorCode == "SERIAL_CODE_REQUIRED")
			return SakashoErrorId.SERIAL_CODE_REQUIRED;
		if(ErrorCode == "CODE_GROUP_ALREADY_FILLED")
			return SakashoErrorId.CODE_GROUP_ALREADY_FILLED;
		if(ErrorCode == "SERIAL_CODE_EXCEED_LIMIT_PER_PLAYER")
			return SakashoErrorId.SERIAL_CODE_EXCEED_LIMIT_PER_PLAYER;
		if(ErrorCode == "FORBIDDEN_BY_TIME_ADJUSTMENT")
			return SakashoErrorId.FORBIDDEN_BY_TIME_ADJUSTMENT;
		if(ErrorCode == "EXCEEDED_MAX_LOGS")
			return SakashoErrorId.EXCEEDED_MAX_LOGS;
		if(ErrorCode == "SAVED_DATA_REACHED_TO_UPDATE_LIMIT")
			return SakashoErrorId.SAVED_DATA_REACHED_TO_UPDATE_LIMIT;
		if(ErrorCode == "NUM_GROUP_KEYS_EXCEEDED")
			return SakashoErrorId.NUM_GROUP_KEYS_EXCEEDED;
		if(ErrorCode == "INVALID_JSON_PATCH")
			return SakashoErrorId.INVALID_JSON_PATCH;
		if(ErrorCode == "PURCHASING_DEFERRED")
			return SakashoErrorId.PURCHASING_DEFERRED;
		if(ErrorCode == "ACTIVE_GAME_NOT_FOUND")
			return SakashoErrorId.ACTIVE_GAME_NOT_FOUND;
		if(ErrorCode == "WRONG_ENVIRONMENT")
			return SakashoErrorId.WRONG_ENVIRONMENT;
		if(ErrorCode == "NORMAL_LOT_ITEM_SETS_NOT_INCLUDED")
			return SakashoErrorId.NORMAL_LOT_ITEM_SETS_NOT_INCLUDED;
		if(ErrorCode == "PLAYER_COUNTER_MASTER_NOT_FOUND")
			return SakashoErrorId.PLAYER_COUNTER_MASTER_NOT_FOUND;
		if(ErrorCode == "PLAYER_COUNTER_MASTER_OUT_OF_SCHEDULE")
			return SakashoErrorId.PLAYER_COUNTER_MASTER_OUT_OF_SCHEDULE;
		if(ErrorCode == "INVALID_COUNT_DELTA")
			return SakashoErrorId.INVALID_COUNT_DELTA;
		if(ErrorCode == "MASTER_GROUP_NOT_FOUND")
			return SakashoErrorId.MASTER_GROUP_NOT_FOUND;
		if(ErrorCode == "RIGHT_REQUIRED")
			return SakashoErrorId.RIGHT_REQUIRED;
		if(ErrorCode == "RIGHT_STACK_PERIOD_OVERFLOW")
			return SakashoErrorId.RIGHT_STACK_PERIOD_OVERFLOW;
		if(ErrorCode == "BLACKLIST_LIMIT_EXCEEDED")
			return SakashoErrorId.BLACKLIST_LIMIT_EXCEEDED;
		if(ErrorCode == "PURCHASE_DISABLED")
			return SakashoErrorId.PURCHASE_DISABLED;
		if(ErrorCode == "RANKING_MASTER_NOT_FOUND")
			return SakashoErrorId.RANKING_MASTER_NOT_FOUND;
		if(ErrorCode == "BIRTHDAY_NOT_REGISTERED")
			return SakashoErrorId.BIRTHDAY_NOT_REGISTERED;
		if(ErrorCode == "NOT_GUILD_MEMBER")
			return SakashoErrorId.NOT_GUILD_MEMBER;
		if(ErrorCode == "GUILD_NOT_FOUND")
			return SakashoErrorId.GUILD_NOT_FOUND;
		if(ErrorCode == "ALREADY_BECOME_GUILD_MEMBER")
			return SakashoErrorId.ALREADY_BECOME_GUILD_MEMBER;
		if(ErrorCode == "ALREADY_APPLIED_GUILD_REQUEST")
			return SakashoErrorId.ALREADY_APPLIED_GUILD_REQUEST;
		if(ErrorCode == "TOO_SHORT_SINCE_LEFT_FROM_GUILD")
			return SakashoErrorId.TOO_SHORT_SINCE_LEFT_FROM_GUILD;
		if(ErrorCode == "TOO_SHORT_SINCE_BE_EXPELLED_FROM_GUILD")
			return SakashoErrorId.TOO_SHORT_SINCE_BE_EXPELLED_FROM_GUILD;
		if(ErrorCode == "NAME_INVALID")
			return SakashoErrorId.NAME_INVALID;
		if(ErrorCode == "DESCRIPTION_INVALID")
			return SakashoErrorId.DESCRIPTION_INVALID;
		if(ErrorCode == "POLICY_ID_INVALID")
			return SakashoErrorId.POLICY_ID_INVALID;
		if(ErrorCode == "NOT_GUILD_MASTER")
			return SakashoErrorId.NOT_GUILD_MASTER;
		if(ErrorCode == "GUILD_REQUEST_NOT_FOUND")
			return SakashoErrorId.GUILD_REQUEST_NOT_FOUND;
		if(ErrorCode == "GUILD_MEMBER_LIMIT_EXCEEDED")
			return SakashoErrorId.GUILD_MEMBER_LIMIT_EXCEEDED;
		if(ErrorCode == "GUILD_RECRUIT_STATUS_IS_STOPPED")
			return SakashoErrorId.GUILD_RECRUIT_STATUS_IS_STOPPED;
		if(ErrorCode == "POINT_LIMIT_OVER")
			return SakashoErrorId.POINT_LIMIT_OVER;
		if(ErrorCode == "INSUFFICIENT_GUILD_POINT")
			return SakashoErrorId.INSUFFICIENT_GUILD_POINT;
		if(ErrorCode == "NOW_GUILD_MASTER")
			return SakashoErrorId.NOW_GUILD_MASTER;
		if(ErrorCode == "CAN_NOT_DELETE_SELF")
			return SakashoErrorId.CAN_NOT_DELETE_SELF;
		if(ErrorCode == "MEMBER_NOT_FOUND")
			return SakashoErrorId.MEMBER_NOT_FOUND;
		if(ErrorCode == "CAN_NOT_ARRANGE_SELF_ORDER")
			return SakashoErrorId.CAN_NOT_ARRANGE_SELF_ORDER;
		if(ErrorCode == "GUILD_MEMBER_NOT_FOUND")
			return SakashoErrorId.GUILD_MEMBER_NOT_FOUND;
		if(ErrorCode == "LAST_GUILD_MEMBER")
			return SakashoErrorId.LAST_GUILD_MEMBER;
		if(ErrorCode == "MORPH_ENGINE_NOT_INITIALIZED")
			return SakashoErrorId.MORPH_ENGINE_NOT_INITIALIZED;
		if(ErrorCode == "MINIMUM_YOUNG_AGE")
			return SakashoErrorId.MINIMUM_YOUNG_AGE;
		if(ErrorCode == "PLAYER_AGE_NOT_MATCHED")
			return SakashoErrorId.PLAYER_AGE_NOT_MATCHED;
		if(ErrorCode == "MORPH_ENGINE_ERROR")
			return SakashoErrorId.MORPH_ENGINE_ERROR;
		if(ErrorCode == "INVALID_CURRENCY_ID")
			return SakashoErrorId.INVALID_CURRENCY_ID;
		if(ErrorCode == "GUILD_REQUEST_FORBIDDEN")
			return SakashoErrorId.GUILD_REQUEST_FORBIDDEN;
		if(ErrorCode == "EXPIRE_DAYS_INVALID")
			return SakashoErrorId.EXPIRE_DAYS_INVALID;
		if(ErrorCode == "NOT_ALLOWED_GAME_SERVER_LINKAGE")
			return SakashoErrorId.NOT_ALLOWED_GAME_SERVER_LINKAGE;
		if(ErrorCode == "ACCESS_FORBIDDEN_BY_IP")
			return SakashoErrorId.ACCESS_FORBIDDEN_BY_IP;
		if(ErrorCode == "RAIDBOSS_ESCAPED")
			return SakashoErrorId.RAIDBOSS_ESCAPED;
		if(ErrorCode == "RAIDBOSS_ATTACK_EXPIRED")
			return SakashoErrorId.RAIDBOSS_ATTACK_EXPIRED;
		if(ErrorCode == "RAIDBOSS_NOT_FOUND")
			return SakashoErrorId.RAIDBOSS_NOT_FOUND;
		if(ErrorCode == "RAIDBOSS_OVER_COUNT_LIMIT")
			return SakashoErrorId.RAIDBOSS_OVER_COUNT_LIMIT;
		if(ErrorCode == "RAIDBOSS_UNIQUE_KEY_NOT_FOUND")
			return SakashoErrorId.RAIDBOSS_UNIQUE_KEY_NOT_FOUND;
		if(ErrorCode == "RAIDBOSS_IS_ALIVE")
			return SakashoErrorId.RAIDBOSS_IS_ALIVE;
		if(ErrorCode == "RAIDBOSS_NOT_ATTACKED")
			return SakashoErrorId.RAIDBOSS_NOT_ATTACKED;
		if(ErrorCode == "RAIDBOSS_MAX_REQUEST_PLAYER_COUNT_EXCEEDED")
			return SakashoErrorId.RAIDBOSS_MAX_REQUEST_PLAYER_COUNT_EXCEEDED;
		if(ErrorCode == "RAIDBOSS_MAX_JOIN_PLAYER_COUNT_EXCEEDED")
			return SakashoErrorId.RAIDBOSS_MAX_JOIN_PLAYER_COUNT_EXCEEDED;
		if(ErrorCode == "RAIDBOSS_KILLED")
			return SakashoErrorId.RAIDBOSS_KILLED;
		if(ErrorCode == "RAIDBOSS_HELP_ALREADY_REQUESTED")
			return SakashoErrorId.RAIDBOSS_HELP_ALREADY_REQUESTED;
		if(ErrorCode == "RAIDBOSS_REWARD_ALREADY_RECEIVED")
			return SakashoErrorId.RAIDBOSS_REWARD_ALREADY_RECEIVED;
		if(ErrorCode == "NOT_PERMITTED_PLAYER_COUNT")
			return SakashoErrorId.NOT_PERMITTED_PLAYER_COUNT;
		if(ErrorCode == "NOT_JOINED_RAIDBOSS")
			return SakashoErrorId.NOT_JOINED_RAIDBOSS;
		if(ErrorCode == "DONATE_GUILD_POINT_LIMIT_EXCEEDED")
			return SakashoErrorId.DONATE_GUILD_POINT_LIMIT_EXCEEDED;
		if(ErrorCode == "STEP_UP_LOT_NOT_FOUND")
			return SakashoErrorId.STEP_UP_LOT_NOT_FOUND;
		if(ErrorCode == "STEP_UP_LOT_TOTAL_COUNT_OVER")
			return SakashoErrorId.STEP_UP_LOT_TOTAL_COUNT_OVER;
		if(ErrorCode == "WRONG_PURCHASE_HASH")
			return SakashoErrorId.WRONG_PURCHASE_HASH;
		if(ErrorCode == "LIMIT_OVER_GUILD_IDS")
			return SakashoErrorId.LIMIT_OVER_GUILD_IDS;
		if(ErrorCode == "INVALID_TWITTER_AUTHENTICATION_DATA")
			return SakashoErrorId.INVALID_TWITTER_AUTHENTICATION_DATA;
		if(ErrorCode == "GAME_NOT_TWITTER_LINKAGE")
			return SakashoErrorId.GAME_NOT_TWITTER_LINKAGE;
		if(ErrorCode == "PLAYER_TWITTER_DATA_NOT_FOUND")
			return SakashoErrorId.PLAYER_TWITTER_DATA_NOT_FOUND;
		if(ErrorCode == "ANOTHER_TWITTER_USER_ID_ALREADY_EXISTS")
			return SakashoErrorId.ANOTHER_TWITTER_USER_ID_ALREADY_EXISTS;
		if(ErrorCode == "TWITTER_USER_ID_ALREADY_EXISTS")
			return SakashoErrorId.TWITTER_USER_ID_ALREADY_EXISTS;
		if(ErrorCode == "RANKING_DROPPED_PLAYER")
			return SakashoErrorId.RANKING_DROPPED_PLAYER;
		if(ErrorCode == "GAME_NOT_LINE_LINKAGE")
			return SakashoErrorId.GAME_NOT_LINE_LINKAGE;
		if(ErrorCode == "ANOTHER_LINE_MID_ALREADY_EXISTS")
			return SakashoErrorId.ANOTHER_LINE_MID_ALREADY_EXISTS;
		if(ErrorCode == "LINE_MID_ALREADY_EXISTS")
			return SakashoErrorId.LINE_MID_ALREADY_EXISTS;
		if(ErrorCode == "INVALID_LINE_AUTHENTICATION_DATA")
			return SakashoErrorId.INVALID_LINE_AUTHENTICATION_DATA;
		if(ErrorCode == "PLAYER_LINE_DATA_NOT_FOUND")
			return SakashoErrorId.PLAYER_LINE_DATA_NOT_FOUND;
		if(ErrorCode == "SHARED_RESOURCE_NOT_FOUND")
			return SakashoErrorId.SHARED_RESOURCE_NOT_FOUND;
		if(ErrorCode == "SHARED_RESOURCE_TYPE_NOT_FOUND")
			return SakashoErrorId.SHARED_RESOURCE_TYPE_NOT_FOUND;
		if(ErrorCode == "SEND_MESSAGE_FAILED")
			return SakashoErrorId.SEND_MESSAGE_FAILED;
		if(ErrorCode == "CREDENTIAL_NOT_FOUND")
			return SakashoErrorId.CREDENTIAL_NOT_FOUND;
		if(ErrorCode == "INVALID_FACEBOOK_AUTHENTICATION_DATA")
			return SakashoErrorId.INVALID_FACEBOOK_AUTHENTICATION_DATA;
		if(ErrorCode == "INACTIVE_PLAYER_DEVICE")
			return SakashoErrorId.INACTIVE_PLAYER_DEVICE;
		if(ErrorCode == "ACTIVATE_DEVICE_REACHED_TO_UPDATE_LIMIT")
			return SakashoErrorId.ACTIVATE_DEVICE_REACHED_TO_UPDATE_LIMIT;
		if(ErrorCode == "ACTIVATE_FROM_OTHER_PLATFORM_DEVICE_NOT_ALLOWED")
			return SakashoErrorId.ACTIVATE_FROM_OTHER_PLATFORM_DEVICE_NOT_ALLOWED;
		if(ErrorCode == "INVALID_PLAYER_TOKEN")
			return SakashoErrorId.INVALID_PLAYER_TOKEN;
		if(ErrorCode == "ALREADY_CREATED_SHARED_RESOURCE")
			return SakashoErrorId.ALREADY_CREATED_SHARED_RESOURCE;
		if(ErrorCode == "UNIQUE_SHARED_RESOURCE_FAILED")
			return SakashoErrorId.UNIQUE_SHARED_RESOURCE_FAILED;
		if(ErrorCode == "INVALID_VIRTUAL_CURRENCY")
			return SakashoErrorId.INVALID_VIRTUAL_CURRENCY;
		if(ErrorCode == "NORMAL_LOT_WITH_FREE_SETTING_QUANTITY_INVALID")
			return SakashoErrorId.NORMAL_LOT_WITH_FREE_SETTING_QUANTITY_INVALID;
		if(ErrorCode == "GUILD_REQUEST_UNNECESSARY")
			return SakashoErrorId.GUILD_REQUEST_UNNECESSARY;
		if(ErrorCode == "DENY_GUILD_JOIN_REQUEST")
			return SakashoErrorId.DENY_GUILD_JOIN_REQUEST;
		if(ErrorCode == "PARAMETER_LIMIT_EXCEEDED")
			return SakashoErrorId.PARAMETER_LIMIT_EXCEEDED;
		if(ErrorCode == "RESOURCE_NOT_FOUND")
			return SakashoErrorId.RESOURCE_NOT_FOUND;
		if(ErrorCode == "RESOURCE_CONFLICT")
			return SakashoErrorId.RESOURCE_CONFLICT;
		if(ErrorCode == "BAD_REQUEST")
			return SakashoErrorId.BAD_REQUEST;
		if(ErrorCode == "PARTICIPANTS_NOT_READY_FOR_MO_RAIDBOSS")
			return SakashoErrorId.PARTICIPANTS_NOT_READY_FOR_MO_RAIDBOSS;
		if(ErrorCode == "NOT_JOINED_MULTIPLAY")
			return SakashoErrorId.NOT_JOINED_MULTIPLAY;
		if(ErrorCode == "ALREADY_CLOSED_TRANSACTION")
			return SakashoErrorId.ALREADY_CLOSED_TRANSACTION;
		if(ErrorCode == "ANDAPP_ERROR_GET_PRODUCTS")
			return SakashoErrorId.ANDAPP_ERROR_GET_PRODUCTS;
		if(ErrorCode == "ANDAPP_ERROR_PURCHASE")
			return SakashoErrorId.ANDAPP_ERROR_PURCHASE;
		if(ErrorCode == "ANDAPP_ERROR_SET_INAPPUSERID")
			return SakashoErrorId.ANDAPP_ERROR_SET_INAPPUSERID;
		if(ErrorCode == "FCM_GAME_SETTING_NOT_FOUND")
			return SakashoErrorId.FCM_GAME_SETTING_NOT_FOUND;
		if(ErrorCode == "NOT_SUPPORTED_PLATFORM")
			return SakashoErrorId.NOT_SUPPORTED_PLATFORM;
		if(ErrorCode == "TOKEN_NOT_FOUND")
			return SakashoErrorId.TOKEN_NOT_FOUND;
		if(ErrorCode == "ALREADY_REGISTERED_TOKEN")
			return SakashoErrorId.ALREADY_REGISTERED_TOKEN;
		if(ErrorCode == "INVALID_MATCHING")
			return SakashoErrorId.INVALID_MATCHING;
		if(ErrorCode == "TARGET_PLAYER_NOT_FOUND")
			return SakashoErrorId.TARGET_PLAYER_NOT_FOUND;
		if(ErrorCode == "NOT_PERMITTED_DELETE_CHAT_MESSAGE")
			return SakashoErrorId.NOT_PERMITTED_DELETE_CHAT_MESSAGE;
		if(ErrorCode == "CHAT_MESSAGE_NOT_FOUND")
			return SakashoErrorId.CHAT_MESSAGE_NOT_FOUND;
		if(ErrorCode == "MINARAI_MEMBER_NOT_FOUND")
			return SakashoErrorId.MINARAI_MEMBER_NOT_FOUND;
		if(ErrorCode == "NOT_GUILD_MINARAI_MEMBER")
			return SakashoErrorId.NOT_GUILD_MINARAI_MEMBER;
		if(ErrorCode == "ALREADY_BECOME_GUILD_MINARAI_MEMBER")
			return SakashoErrorId.ALREADY_BECOME_GUILD_MINARAI_MEMBER;
		if(ErrorCode == "ALREADY_GUILD_MINARAI_GRADUATE")
			return SakashoErrorId.ALREADY_GUILD_MINARAI_GRADUATE;
		if(ErrorCode == "GUILD_MINARAI_MEMBER_LIMIT_EXCEEDED")
			return SakashoErrorId.GUILD_MINARAI_MEMBER_LIMIT_EXCEEDED;
		if(ErrorCode == "REQUIRED_GUILD_MEMBER_NUM")
			return SakashoErrorId.REQUIRED_GUILD_MEMBER_NUM;
		if(ErrorCode == "GUILD_MINARAI_RECRUIT_STATUS_IS_STOPPED_ERROR")
			return SakashoErrorId.GUILD_MINARAI_RECRUIT_STATUS_IS_STOPPED_ERROR;
		if(ErrorCode == "GUILD_MINARAI_RECRUIT_STATUS_IS_STOPPED")
			return SakashoErrorId.GUILD_MINARAI_RECRUIT_STATUS_IS_STOPPED;
		if(ErrorCode == "ALREADY_ADD_POINT")
			return SakashoErrorId.ALREADY_ADD_POINT;
		if(ErrorCode == "LIMIT_OVER_RAIDBOSS_ENTITY_IDS")
			return SakashoErrorId.LIMIT_OVER_RAIDBOSS_ENTITY_IDS;
		if(ErrorCode == "ALREADY_JOINED_RAIDBOSS")
			return SakashoErrorId.ALREADY_JOINED_RAIDBOSS;
		if(ErrorCode == "DENY_RAIDBOSS_JOIN_REQUEST")
			return SakashoErrorId.DENY_RAIDBOSS_JOIN_REQUEST;
		if(ErrorCode == "OVER_RAIDBOSS_JOIN_DURATION_TIME")
			return SakashoErrorId.OVER_RAIDBOSS_JOIN_DURATION_TIME;
		if(ErrorCode == "RAIDBOSS_HP_IS_TOO_LOW")
			return SakashoErrorId.RAIDBOSS_HP_IS_TOO_LOW;
		if(ErrorCode == "COOPERATIVE_BATTLE_RANK_CONFIG_NOT_FOUND")
			return SakashoErrorId.COOPERATIVE_BATTLE_RANK_CONFIG_NOT_FOUND;
		if(ErrorCode == "GUILD_RANK_CONFIG_NOT_FOUND")
			return SakashoErrorId.GUILD_RANK_CONFIG_NOT_FOUND;
		if(ErrorCode == "INVALID_GOOGLE_API_CLIENT_ID")
			return SakashoErrorId.INVALID_GOOGLE_API_CLIENT_ID;
		if(ErrorCode == "PLAYER_GOOGLE_DATA_NOT_FOUND")
			return SakashoErrorId.PLAYER_GOOGLE_DATA_NOT_FOUND;
		if(ErrorCode == "ANOTHER_GOOGLE_USER_ID_ALREADY_EXISTS")
			return SakashoErrorId.ANOTHER_GOOGLE_USER_ID_ALREADY_EXISTS;
		if(ErrorCode == "GOOGLE_USER_ID_ALREADY_EXISTS")
			return SakashoErrorId.GOOGLE_USER_ID_ALREADY_EXISTS;
		if(ErrorCode == "GOOGLE_SIGN_IN_FAILED")
			return SakashoErrorId.GOOGLE_SIGN_IN_FAILED;
		if(ErrorCode == "GAME_CENTER_VERIFICATION_FAILED")
			return SakashoErrorId.GAME_CENTER_VERIFICATION_FAILED;
		if(ErrorCode == "ANOTHER_GAME_CENTER_PLAYER_ID_ALREADY_EXISTS")
			return SakashoErrorId.ANOTHER_GAME_CENTER_PLAYER_ID_ALREADY_EXISTS;
		if(ErrorCode == "GAME_CENTER_PLAYER_ID_ALREADY_EXISTS")
			return SakashoErrorId.GAME_CENTER_PLAYER_ID_ALREADY_EXISTS;
		if(ErrorCode == "GAME_CENTER_SERVICE_DISABLED")
			return SakashoErrorId.GAME_CENTER_SERVICE_DISABLED;
		if(ErrorCode == "GAME_CENTER_SERVICE_UNAVAILABLE")
			return SakashoErrorId.GAME_CENTER_SERVICE_UNAVAILABLE;
		if(ErrorCode == "PLAYER_GAME_CENTER_DATA_NOT_FOUND")
			return SakashoErrorId.PLAYER_GAME_CENTER_DATA_NOT_FOUND;
		if(ErrorCode == "INVALID_ID_TOKEN")
			return SakashoErrorId.INVALID_ID_TOKEN;
		if(ErrorCode == "NOT_ENOUGH_GACHA_TICKET_AMOUNT")
			return SakashoErrorId.NOT_ENOUGH_GACHA_TICKET_AMOUNT;
		if(ErrorCode == "PLAYER_SAVED_DATA_RECORD_NOT_FOUND")
			return SakashoErrorId.PLAYER_SAVED_DATA_RECORD_NOT_FOUND;
		if(ErrorCode == "CROW_SETTING_NOT_FOUND")
			return SakashoErrorId.CROW_SETTING_NOT_FOUND;
		if(ErrorCode == "ANOTHER_CROW_PLAYER_KEYS_ALREADY_EXISTS")
			return SakashoErrorId.ANOTHER_CROW_PLAYER_KEYS_ALREADY_EXISTS;
		if(ErrorCode == "CROW_PLAYER_KEYS_ALREADY_EXISTS")
			return SakashoErrorId.CROW_PLAYER_KEYS_ALREADY_EXISTS;
		if(ErrorCode == "APPLICATION_VERSION_NOT_FOUND")
			return SakashoErrorId.APPLICATION_VERSION_NOT_FOUND;
		if(ErrorCode == "CROW_SERVER_SERVICE_UNAVAILABLE")
			return SakashoErrorId.CROW_SERVER_SERVICE_UNAVAILABLE;
		if(ErrorCode == "CROW_SERVER_ERROR")
			return SakashoErrorId.CROW_SERVER_ERROR;
		if(ErrorCode == "INVALID_UDKEY")
			return SakashoErrorId.INVALID_UDKEY;
		if(ErrorCode == "INVALID_GDKEY")
			return SakashoErrorId.INVALID_GDKEY;
		if(ErrorCode == "SIGN_IN_WITH_APPLE_UNAVAILABLE_UNDER_IOS_13")
			return SakashoErrorId.SIGN_IN_WITH_APPLE_UNAVAILABLE_UNDER_IOS_13;
		if(ErrorCode == "APPLE_VERIFICATION_FAILED")
			return SakashoErrorId.APPLE_VERIFICATION_FAILED;
		if(ErrorCode == "ANOTHER_APPLE_USER_ID_ALREADY_EXISTS")
			return SakashoErrorId.ANOTHER_APPLE_USER_ID_ALREADY_EXISTS;
		if(ErrorCode == "APPLE_USER_ID_ALREADY_EXISTS")
			return SakashoErrorId.APPLE_USER_ID_ALREADY_EXISTS;
		if(ErrorCode == "SIGN_IN_WITH_APPLE_UNAVAILABLE")
			return SakashoErrorId.SIGN_IN_WITH_APPLE_UNAVAILABLE;
		if(ErrorCode == "PLAYER_APPLE_DATA_NOT_FOUND")
			return SakashoErrorId.PLAYER_APPLE_DATA_NOT_FOUND;
		if(ErrorCode == "MULTI_VC_STEP_UP_LOT_NOT_FOUND")
			return SakashoErrorId.MULTI_VC_STEP_UP_LOT_NOT_FOUND;
		if(ErrorCode == "VIRTUAL_CURRENCY_NOT_FOUND")
			return SakashoErrorId.VIRTUAL_CURRENCY_NOT_FOUND;
		if(ErrorCode == "MULTI_VC_STEP_UP_LOT_TOTAL_COUNT_OVER")
			return SakashoErrorId.MULTI_VC_STEP_UP_LOT_TOTAL_COUNT_OVER;
		if(ErrorCode == "LIMIT_OVER_VIRTUAL_CURRENCY_IDS")
			return SakashoErrorId.LIMIT_OVER_VIRTUAL_CURRENCY_IDS;
		if(ErrorCode == "LIMIT_OVER_UNIQUE_KEYS")
			return SakashoErrorId.LIMIT_OVER_UNIQUE_KEYS;
		if(ErrorCode == "UNIQUE_KEYS_NOT_FOUND")
			return SakashoErrorId.UNIQUE_KEYS_NOT_FOUND;
		if(ErrorCode == "RECEIVED_COUNT_LIMIT_EXCEEDED")
			return SakashoErrorId.RECEIVED_COUNT_LIMIT_EXCEEDED;
		if(ErrorCode == "INTERRUPT_RAIDBOSS_NOT_FOUND")
			return SakashoErrorId.INTERRUPT_RAIDBOSS_NOT_FOUND;
		if(ErrorCode == "LIMIT_OVER_PRODUCT_IDS")
			return SakashoErrorId.LIMIT_OVER_PRODUCT_IDS;
		if(ErrorCode == "PENDING_TRANSACTION_OCCURED")
			return SakashoErrorId.PENDING_TRANSACTION_OCCURED;
		if(ErrorCode == "PENDING_TRANSACTION_PAYMENT_WAITING")
			return SakashoErrorId.PENDING_TRANSACTION_PAYMENT_WAITING;
		if(ErrorCode == "INVALID_PRODUCT_IDS")
			return SakashoErrorId.INVALID_PRODUCT_IDS;
		return SakashoErrorId.UNKNOWN;
	}
}

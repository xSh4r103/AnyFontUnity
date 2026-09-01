using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AnyFontUnity
{
    // Multilingual support (Localization) layer, managing the translation dictionary for the entire user interface
    public static class Loc
    {
        public static string Current = "VI";

        // The dictionary contains translated text strings for multiple languages
        private static readonly Dictionary<string, Dictionary<string, string>> dict = new Dictionary<string, Dictionary<string, string>>()
        {
            { "VI", new Dictionary<string, string> {
                { "Btn1_Default", "1. PATH LOADER GAME" },
                { "Btn2_Default", "2. RUN & LOADER GAME" },
                { "Btn3_Default", "3. PATH .DLL + .TFF" },
                { "Btn1_Ready", "SẴN SÀNG CÀI ĐẶT PATCH" },
                { "Btn1_Done", "1. DONE" },
                { "Btn2_Ready", "SẴN SÀNG CHẠY GAME" },
                { "Btn2_Watch", "ĐANG THEO DÕI..." },
                { "Btn2_Retry", "THỬ LẠI BƯỚC 2" },
                { "Btn2_Done", "2. DONE" },
                { "Btn3_Ready", "PATH .dll + .tff" },
                { "Btn3_Done", "3. COMPLETE" },
                { "Status_WaitExe", "Trạng thái: Đang chờ chọn file game .exe..." },
                { "Status_ValidExe", "Trạng thái: Game hợp lệ, chờ cài đặt Patch." },
                { "Status_InvalidExe", "Trạng thái: Vui lòng chọn lại file .exe hợp lệ." },
                { "Status_Patching", "Trạng thái: Đang nạp {0}..." },
                { "Status_WaitRun", "Trạng thái: Chờ chạy game lần đầu để lấy log." },
                { "Status_PatchFail", "Trạng thái: Nạp Patch thất bại. Hãy thử lại." },
                { "Status_EngineStart", "Trạng thái: Đang khởi chạy hệ thống engine..." },
                { "Status_WaitLog", "Trạng thái: Đang chờ nạp log (Có thể mất 1-2 phút)..." },
                { "Status_HookSuccess", "Trạng thái: ĐÃ HOOK XONG! Bạn có thể tắt game." },
                { "Status_HookFail", "Trạng thái: Hook thất bại. Hãy thử lại." },
                { "Status_Injecting", "Trạng thái: Đang nạp DLL và Font..." },
                { "Status_AllDone", "Trạng thái: HOÀN TẤT 100%!" },
                { "Status_InjectFail", "Trạng thái: Nạp file thất bại. Hãy thử lại." },
                { "Credit", "Phiên bản v1.0.0 : 2026" },
                { "Msg_InvalidTarget", "Đây không phải là thư mục game Unity hợp lệ!\n\nVui lòng không chọn lối tắt (Shortcut) ngoài Desktop.\nHãy vào sâu trong thư mục cài đặt game và chọn file .exe gốc." },
                { "Msg_ExtractError", "Có lỗi xảy ra khi nạp Patch:\n" },
                { "Msg_HookInstruct", "HỆ THỐNG SẼ TỰ ĐỘNG KHỞI CHẠY GAME.\n\n- Lần chạy đầu tiên sẽ mất khoảng 1 đến 2 phút để Core Framework giải nén dữ liệu lõi.\n- Khi bạn thấy game đã vào được đến Màn hình chính (Menu), HÃY TỰ TẮT GAME.\n\nNhấn OK để bắt đầu quá trình Hook!" },
                { "Msg_LogTimeout", "Quá thời gian không tìm thấy file Latest.log.\nCó thể game đã bị crash hoặc hệ thống bảo vệ đã chặn." },
                { "Msg_HookTimeout", "Quá thời gian chờ đọc log (5 phút). Quá trình Hook bị treo." },
                { "Msg_HookError", "Có lỗi xảy ra khi theo dõi log:\n" },
                { "Msg_Done", "Đã setup Mod và Font thành công!\n\nBạn có thể khởi động lại game để trải nghiệm Việt Hóa mượt mà." },
                { "VS_Title", "CHỌN PHIÊN BẢN" },
                { "VS_Confirm", "XÁC NHẬN" },
                { "FC_Title", "PATH .DLL" },
                { "FC_DllNote", "Vui lòng chọn đúng kiến trúc\nengine của game (IL2CPP/MONO)." },
                { "FC_FontTitle", "CẤU HÌNH FONT .TFF" },
                { "FC_FontDesc", "Bạn muốn dùng font .tff của hệ thống hay font .tff của bạn?\n\n(Font hệ thống đã hỗ trợ đầy đủ toàn bộ ngôn ngữ)" },
                { "FC_SysFont", ".TFF HỆ THỐNG" },
                { "FC_CustomFont", ".TFF RIÊNG" }
            }},
            { "EN", new Dictionary<string, string> {
                { "Btn1_Default", "1. PATH LOADER GAME" },
                { "Btn2_Default", "2. RUN & LOADER GAME" },
                { "Btn3_Default", "3. PATH .DLL + .TFF" },
                { "Btn1_Ready", "READY TO INSTALL PATCH" },
                { "Btn1_Done", "1. DONE" },
                { "Btn2_Ready", "READY TO RUN GAME" },
                { "Btn2_Watch", "MONITORING..." },
                { "Btn2_Retry", "RETRY STEP 2" },
                { "Btn2_Done", "2. DONE" },
                { "Btn3_Ready", "PATH .dll + .tff" },
                { "Btn3_Done", "3. COMPLETE" },
                { "Status_WaitExe", "Status: Waiting for game .exe file..." },
                { "Status_ValidExe", "Status: Valid game, ready to patch." },
                { "Status_InvalidExe", "Status: Please select a valid .exe file." },
                { "Status_Patching", "Status: Injecting {0}..." },
                { "Status_WaitRun", "Status: Waiting for first launch to get logs." },
                { "Status_PatchFail", "Status: Patch failed. Please try again." },
                { "Status_EngineStart", "Status: Starting engine system..." },
                { "Status_WaitLog", "Status: Waiting for logs (May take 1-2 mins)..." },
                { "Status_HookSuccess", "Status: HOOK SUCCESSFUL! You can close the game." },
                { "Status_HookFail", "Status: Hook failed. Please try again." },
                { "Status_Injecting", "Status: Injecting DLL and Font..." },
                { "Status_AllDone", "Status: 100% COMPLETE!" },
                { "Status_InjectFail", "Status: Injection failed. Please try again." },
                { "Credit", "Version v1.0.0 : 2026" },
                { "Msg_InvalidTarget", "This is not a valid Unity game folder!\n\nPlease do not select a Desktop Shortcut.\nNavigate to the game directory and select the original .exe file." },
                { "Msg_ExtractError", "An error occurred during patching:\n" },
                { "Msg_HookInstruct", "THE SYSTEM WILL AUTOMATICALLY LAUNCH THE GAME.\n\n- The first launch will take 1-2 minutes to extract core data.\n- Once you reach the Main Menu, PLEASE CLOSE THE GAME MANUALLY.\n\nPress OK to start the Hook process!" },
                { "Msg_LogTimeout", "Timeout: Latest.log not found.\nThe game might have crashed or blocked by protection." },
                { "Msg_HookTimeout", "Timeout reading logs (5 mins). Hook process hung." },
                { "Msg_HookError", "An error occurred while monitoring logs:\n" },
                { "Msg_Done", "Mod and Font setup completed successfully!\n\nYou can restart the game to experience seamless localized text." },
                { "VS_Title", "SELECT VERSION" },
                { "VS_Confirm", "CONFIRM" },
                { "FC_Title", "DLL PATH" },
                { "FC_DllNote", "Please select the correct\ngame architecture (IL2CPP/MONO)." },
                { "FC_FontTitle", "TFF FONT CONFIG" },
                { "FC_FontDesc", "Do you want to use the system .tff font or your own?\n\n(System font supports all languages completely)" },
                { "FC_SysFont", "SYSTEM .TFF" },
                { "FC_CustomFont", "CUSTOM .TFF" }
            }},
            { "ZH", new Dictionary<string, string> {
                { "Btn1_Default", "1. 挂载游戏加载器" },
                { "Btn2_Default", "2. 运行并挂载游戏" },
                { "Btn3_Default", "3. 挂载 .DLL + .TFF" },
                { "Btn1_Ready", "准备安装补丁" },
                { "Btn1_Done", "1. 完成" },
                { "Btn2_Ready", "准备运行游戏" },
                { "Btn2_Watch", "监控中..." },
                { "Btn2_Retry", "重试第二步" },
                { "Btn2_Done", "2. 完成" },
                { "Btn3_Ready", "PATH .dll + .tff" },
                { "Btn3_Done", "3. 完成" },
                { "Status_WaitExe", "状态：等待选择游戏 .exe 文件..." },
                { "Status_ValidExe", "状态：游戏有效，等待安装补丁。" },
                { "Status_InvalidExe", "状态：请重新选择有效的 .exe 文件。" },
                { "Status_Patching", "状态：正在注入 {0}..." },
                { "Status_WaitRun", "状态：等待首次运行以获取日志。" },
                { "Status_PatchFail", "状态：补丁安装失败，请重试。" },
                { "Status_EngineStart", "状态：正在启动引擎系统..." },
                { "Status_WaitLog", "状态：等待日志生成（可能需要1-2分钟）..." },
                { "Status_HookSuccess", "状态：挂载成功！您可以关闭游戏了。" },
                { "Status_HookFail", "状态：挂载失败，请重试。" },
                { "Status_Injecting", "状态：正在注入 DLL 和字体..." },
                { "Status_AllDone", "状态：100% 完成！" },
                { "Status_InjectFail", "状态：注入失败，请重试。" },
                { "Credit", "版本 v1.0.0 : 2026" },
                { "Msg_InvalidTarget", "这不是有效的 Unity 游戏文件夹！\n\n请不要选择桌面快捷方式。\n请进入游戏安装目录并选择原始的 .exe 文件。" },
                { "Msg_ExtractError", "安装补丁时发生错误：\n" },
                { "Msg_HookInstruct", "系统将自动启动游戏。\n\n- 首次启动需要 1-2 分钟来解压核心数据。\n- 当游戏进入主菜单时，请手动关闭游戏。\n\n点击确定开始挂载过程！" },
                { "Msg_LogTimeout", "超时：未找到 Latest.log。\n游戏可能已崩溃或被保护系统拦截。" },
                { "Msg_HookTimeout", "读取日志超时（5分钟）。挂载过程卡住。" },
                { "Msg_HookError", "监控日志时发生错误：\n" },
                { "Msg_Done", "Mod 和字体设置成功！\n\n您可以重启游戏以体验流畅的汉化。" },
                { "VS_Title", "选择版本" },
                { "VS_Confirm", "确认" },
                { "FC_Title", "DLL 路径" },
                { "FC_DllNote", "请选择正确的游戏架构\n（IL2CPP 或 MONO）。" },
                { "FC_FontTitle", "TFF 字体配置" },
                { "FC_FontDesc", "您想使用系统 .tff 字体还是您自己的字体？\n\n（系统字体已完全支持所有语言）" },
                { "FC_SysFont", "系统 .TFF" },
                { "FC_CustomFont", "自定义 .TFF" }
            }},
            { "TW", new Dictionary<string, string> {
                { "Btn1_Default", "1. 掛載遊戲加載器" },
                { "Btn2_Default", "2. 運行並掛載遊戲" },
                { "Btn3_Default", "3. 掛載 .DLL + .TFF" },
                { "Btn1_Ready", "準備安裝補丁" },
                { "Btn1_Done", "1. 完成" },
                { "Btn2_Ready", "準備運行遊戲" },
                { "Btn2_Watch", "監控中..." },
                { "Btn2_Retry", "重試第二步" },
                { "Btn2_Done", "2. 完成" },
                { "Btn3_Ready", "PATH .dll + .tff" },
                { "Btn3_Done", "3. 完成" },
                { "Status_WaitExe", "狀態：等待選擇遊戲 .exe 文件..." },
                { "Status_ValidExe", "狀態：遊戲有效，等待安裝補丁。" },
                { "Status_InvalidExe", "狀態：請重新選擇有效的 .exe 文件。" },
                { "Status_Patching", "狀態：正在注入 {0}..." },
                { "Status_WaitRun", "狀態：等待首次運行以獲取日誌。" },
                { "Status_PatchFail", "狀態：補丁安裝失敗，請重試。" },
                { "Status_EngineStart", "狀態：正在啟動引擎系統..." },
                { "Status_WaitLog", "狀態：等待日誌生成（可能需要1-2分鐘）..." },
                { "Status_HookSuccess", "狀態：掛載成功！您可以關閉遊戲了。" },
                { "Status_HookFail", "狀態：掛載失敗，請重試。" },
                { "Status_Injecting", "狀態：正在注入 DLL 和字體..." },
                { "Status_AllDone", "狀態：100% 完成！" },
                { "Status_InjectFail", "狀態：注入失敗，請重試。" },
                { "Credit", "版本 v1.0.0 : 2026" },
                { "Msg_InvalidTarget", "這不是有效的 Unity 遊戲資料夾！\n\n請不要選擇桌面捷徑。\n請進入遊戲安裝目錄並選擇原始的 .exe 文件。" },
                { "Msg_ExtractError", "安裝補丁時發生錯誤：\n" },
                { "Msg_HookInstruct", "系統將自動啟動遊戲。\n\n- 首次啟動需要 1-2 分鐘來解壓核心數據。\n- 當遊戲進入主選單時，請手動關閉遊戲。\n\n點擊確定開始掛載過程！" },
                { "Msg_LogTimeout", "超時：未找到 Latest.log。\n遊戲可能已崩潰或被保護系統攔截。" },
                { "Msg_HookTimeout", "讀取日誌超時（5分鐘）。掛載過程卡住。" },
                { "Msg_HookError", "監控日誌時發生錯誤：\n" },
                { "Msg_Done", "Mod 和字體設置成功！\n\n您可以重啟遊戲以體驗流暢的繁體中文化。" },
                { "VS_Title", "選擇版本" },
                { "VS_Confirm", "確認" },
                { "FC_Title", "DLL 路徑" },
                { "FC_DllNote", "請選擇正確的遊戲架構\n（IL2CPP 或 MONO）。" },
                { "FC_FontTitle", "TFF 字體配置" },
                { "FC_FontDesc", "您想使用系統 .tff 字體還是您自己的字體？\n\n（系統字體已完全支持所有語言）" },
                { "FC_SysFont", "系統 .TFF" },
                { "FC_CustomFont", "自定義 .TFF" }
            }},
            { "RU", new Dictionary<string, string> {
                { "Btn1_Default", "1. ПУТЬ ЗАГРУЗЧИКА ИГРЫ" },
                { "Btn2_Default", "2. ЗАПУСК И ЗАГРУЗЧИК" },
                { "Btn3_Default", "3. ПУТЬ .DLL + .TFF" },
                { "Btn1_Ready", "ГОТОВ К УСТАНОВКЕ ПАТЧА" },
                { "Btn1_Done", "1. ГОТОВО" },
                { "Btn2_Ready", "ГОТОВ К ЗАПУСКУ" },
                { "Btn2_Watch", "МОНИТОРИНГ..." },
                { "Btn2_Retry", "ПОВТОРИТЬ ШАГ 2" },
                { "Btn2_Done", "2. ГОТОВО" },
                { "Btn3_Ready", "PATH .dll + .tff" },
                { "Btn3_Done", "3. ЗАВЕРШЕНО" },
                { "Status_WaitExe", "Статус: Ожидание выбора файла .exe..." },
                { "Status_ValidExe", "Статус: Игра валидна, ожидание установки." },
                { "Status_InvalidExe", "Статус: Пожалуйста, выберите валидный .exe." },
                { "Status_Patching", "Статус: Инъекция {0}..." },
                { "Status_WaitRun", "Статус: Ожидание первого запуска для логов." },
                { "Status_PatchFail", "Статус: Ошибка патча. Попробуйте снова." },
                { "Status_EngineStart", "Статус: Запуск системы движка..." },
                { "Status_WaitLog", "Статус: Ожидание логов (1-2 мин)..." },
                { "Status_HookSuccess", "Статус: ХУК УСПЕШЕН! Можете закрыть игру." },
                { "Status_HookFail", "Статус: Ошибка хука. Попробуйте снова." },
                { "Status_Injecting", "Статус: Инъекция DLL и Шрифта..." },
                { "Status_AllDone", "Статус: 100% ЗАВЕРШЕНО!" },
                { "Status_InjectFail", "Статус: Ошибка инъекции. Попробуйте снова." },
                { "Credit", "Версия v1.0.0 : 2026" },
                { "Msg_InvalidTarget", "Это не валидная папка игры Unity!\n\nНе выбирайте ярлык на рабочем столе.\nПерейдите в папку с игрой и выберите .exe файл." },
                { "Msg_ExtractError", "Ошибка при установке патча:\n" },
                { "Msg_HookInstruct", "СИСТЕМА АВТОМАТИЧЕСКИ ЗАПУСТИТ ИГРУ.\n\n- Первый запуск займет 1-2 минуты для распаковки.\n- Когда дойдете до Главного меню, ЗАКРОЙТЕ ИГРУ ВРУЧНУЮ.\n\nНажмите ОК для начала Хука!" },
                { "Msg_LogTimeout", "Таймаут: Latest.log не найден.\nИгра могла вылететь или заблокирована защитой." },
                { "Msg_HookTimeout", "Таймаут чтения логов. Процесс хука завис." },
                { "Msg_HookError", "Ошибка при мониторинге логов:\n" },
                { "Msg_Done", "Мод и шрифт успешно установлены!\n\nМожете перезапустить игру для проверки." },
                { "VS_Title", "ВЫБЕРИТЕ ВЕРСИЮ" },
                { "VS_Confirm", "ПОДТВЕРДИТЬ" },
                { "FC_Title", "ПУТЬ DLL" },
                { "FC_DllNote", "Пожалуйста, выберите правильную\nархитектуру игры (IL2CPP/MONO)." },
                { "FC_FontTitle", "НАСТРОЙКА ШРИФТА .TFF" },
                { "FC_FontDesc", "Использовать системный шрифт или свой?\n\n(Системный шрифт поддерживает все языки)" },
                { "FC_SysFont", "СИСТЕМНЫЙ .TFF" },
                { "FC_CustomFont", "СВОЙ .TFF" }
            }},
            { "KO", new Dictionary<string, string> {
                { "Btn1_Default", "1. 게임 로더 패치" },
                { "Btn2_Default", "2. 게임 실행 및 후킹" },
                { "Btn3_Default", "3. .DLL + .TFF 주입" },
                { "Btn1_Ready", "패치 설치 준비 완료" },
                { "Btn1_Done", "1. 완료" },
                { "Btn2_Ready", "게임 실행 준비 완료" },
                { "Btn2_Watch", "모니터링 중..." },
                { "Btn2_Retry", "2단계 재시도" },
                { "Btn2_Done", "2. 완료" },
                { "Btn3_Ready", "PATH .dll + .tff" },
                { "Btn3_Done", "3. 완료" },
                { "Status_WaitExe", "상태: 게임 .exe 파일 선택 대기 중..." },
                { "Status_ValidExe", "상태: 유효한 게임, 패치 설치 대기 중." },
                { "Status_InvalidExe", "상태: 유효한 .exe 파일을 다시 선택하세요." },
                { "Status_Patching", "상태: {0} 주입 중..." },
                { "Status_WaitRun", "상태: 로그를 얻기 위한 첫 실행 대기 중." },
                { "Status_PatchFail", "상태: 패치 실패. 다시 시도하세요." },
                { "Status_EngineStart", "상태: 엔진 시스템 시작 중..." },
                { "Status_WaitLog", "상태: 로그 대기 중 (1-2분 소요)..." },
                { "Status_HookSuccess", "상태: 후킹 성공! 게임을 닫으셔도 됩니다." },
                { "Status_HookFail", "상태: 후킹 실패. 다시 시도하세요." },
                { "Status_Injecting", "상태: DLL 및 폰트 주입 중..." },
                { "Status_AllDone", "상태: 100% 완료!" },
                { "Status_InjectFail", "상태: 파일 주입 실패. 다시 시도하세요." },
                { "Credit", "버전 v1.0.0 : 2026" },
                { "Msg_InvalidTarget", "유효한 Unity 게임 폴더가 아닙니다!\n\n바탕화면 바로가기를 선택하지 마세요.\n게임 설치 폴더로 이동하여 원본 .exe를 선택하세요." },
                { "Msg_ExtractError", "패치 설치 중 오류 발생:\n" },
                { "Msg_HookInstruct", "시스템이 자동으로 게임을 실행합니다.\n\n- 첫 실행 시 코어 데이터 압축 해제에 1~2분이 소요됩니다.\n- 메인 메뉴에 진입하면 수동으로 게임을 종료해 주세요.\n\n확인을 눌러 후킹을 시작합니다!" },
                { "Msg_LogTimeout", "시간 초과: Latest.log를 찾을 수 없습니다.\n게임이 크래시되었거나 보호 시스템에 차단되었을 수 있습니다." },
                { "Msg_HookTimeout", "로그 읽기 시간 초과(5분). 후킹 프로세스 중단." },
                { "Msg_HookError", "로그 모니터링 중 오류 발생:\n" },
                { "Msg_Done", "모드 및 폰트 설정 성공!\n\n게임을 재시작하여 원활한 한글화를 경험하세요." },
                { "VS_Title", "버전 선택" },
                { "VS_Confirm", "확인" },
                { "FC_Title", "DLL 경로" },
                { "FC_DllNote", "올바른 게임 아키텍처를\n선택하세요 (IL2CPP/MONO)." },
                { "FC_FontTitle", "TFF 폰트 설정" },
                { "FC_FontDesc", "시스템 폰트를 사용하시겠습니까, 아니면 커스텀 폰트를 사용하시겠습니까?\n\n(시스템 폰트는 모든 언어를 완벽히 지원합니다)" },
                { "FC_SysFont", "시스템 .TFF" },
                { "FC_CustomFont", "커스텀 .TFF" }
            }},
            { "JA", new Dictionary<string, string> {
                { "Btn1_Default", "1. ゲームローダーをパッチ" },
                { "Btn2_Default", "2. ゲームの実行とフック" },
                { "Btn3_Default", "3. .DLL + .TFF を注入" },
                { "Btn1_Ready", "パッチインストールの準備完了" },
                { "Btn1_Done", "1. 完了" },
                { "Btn2_Ready", "ゲーム起動の準備完了" },
                { "Btn2_Watch", "監視中..." },
                { "Btn2_Retry", "ステップ2を再試行" },
                { "Btn2_Done", "2. 完了" },
                { "Btn3_Ready", "PATH .dll + .tff" },
                { "Btn3_Done", "3. 完了" },
                { "Status_WaitExe", "ステータス: ゲームの.exeファイルを選択待ち..." },
                { "Status_ValidExe", "ステータス: 有効なゲーム、パッチ待機中。" },
                { "Status_InvalidExe", "ステータス: 有効な.exeを再選択してください。" },
                { "Status_Patching", "ステータス: {0} を注入中..." },
                { "Status_WaitRun", "ステータス: ログ取得のため初回起動待機中。" },
                { "Status_PatchFail", "ステータス: パッチ失敗。再試行してください。" },
                { "Status_EngineStart", "ステータス: エンジンシステムを起動中..." },
                { "Status_WaitLog", "ステータス: ログ待機中（1〜2分かかります）..." },
                { "Status_HookSuccess", "ステータス: フック成功！ゲームを閉じても安全です。" },
                { "Status_HookFail", "ステータス: フック失敗。再試行してください。" },
                { "Status_Injecting", "ステータス: DLLとフォントを注入中..." },
                { "Status_AllDone", "ステータス: 100% 完了！" },
                { "Status_InjectFail", "ステータス: 注入失敗。再試行してください。" },
                { "Credit", "バージョン v1.0.0 : 2026" },
                { "Msg_InvalidTarget", "有効なUnityゲームフォルダではありません！\n\nデスクトップのショートカットは選択しないでください。\nインストールフォルダ内の元の.exeを選択してください。" },
                { "Msg_ExtractError", "パッチ中にエラーが発生しました:\n" },
                { "Msg_HookInstruct", "システムが自動的にゲームを起動します。\n\n- 初回起動時はコアデータの解凍に1〜2分かかります。\n- メインメニューに到達したら、手動でゲームを閉じてください。\n\nOKを押してフック処理を開始します！" },
                { "Msg_LogTimeout", "タイムアウト: Latest.logが見つかりません。\nクラッシュしたか保護システムにブロックされました。" },
                { "Msg_HookTimeout", "ログ読み取りタイムアウト（5分）。処理が停止しました。" },
                { "Msg_HookError", "ログ監視中にエラーが発生しました:\n" },
                { "Msg_Done", "Modとフォントのセットアップが成功しました！\n\nゲームを再起動して日本語化を確認してください。" },
                { "VS_Title", "バージョン選択" },
                { "VS_Confirm", "確認" },
                { "FC_Title", "DLL パス" },
                { "FC_DllNote", "正しいゲームアーキテクチャを\n選択してください（IL2CPP/MONO）。" },
                { "FC_FontTitle", "TFF フォント設定" },
                { "FC_FontDesc", "システムの.tffを使用しますか、それとも独自のフォントを使用しますか？\n\n（システムフォントは全言語を完全サポートしています）" },
                { "FC_SysFont", "システム .TFF" },
                { "FC_CustomFont", "カスタム .TFF" }
            }}
        };

        // Retrieve the translation string corresponding to the key based on the current locale
        public static string Get(string key)
        {
            if (dict.ContainsKey(Current) && dict[Current].ContainsKey(key))
                return dict[Current][key];

            // Fallback to Vietnamese if the current language cannot be found
            if (dict["VI"].ContainsKey(key)) return dict["VI"][key];
            return key;
        }
    }

    // The main application interface (Windows Forms) featuring a Cyberpunk-style design
    public partial class Form1 : Form
    {
        // User Interface (UI) Controls
        private RichTextBox txtConsole;
        private TextBox txtPath;
        private Button btnBrowse;
        private Button btnStep1_PathHook;
        private Button btnStep2_RunHook;
        private Button btnStep3_SelectFont;
        private Label lblStatus;
        private Label lblCredit;
        private ComboBox cbLanguage;

        // Variable for storing the path
        private string gameFolderPath = "";
        private string gameExePath = "";
        private Random rnd = new Random();

        // Update the current node or label state to support multiple languages
        private string currentStatusKey = "Status_WaitExe";
        private string btn1Key = "Btn1_Default";
        private string btn2Key = "Btn2_Default";
        private string btn3Key = "Btn3_Default";
        private string formatParam = "";

        public Form1()
        {
            SetupCyberpunkUI();
            AppendLog("[SYSTEM] BOOT SEQUENCE INITIATED...");
            AppendLog("[SYSTEM] WAITING FOR TARGET GAME EXECUTABLE...");
            UpdateUITexts();
        }

        // Set up a Cyberpunk-style dark theme for the main form
        private void SetupCyberpunkUI()
        {
            this.Text = "AnyFontUnity - by Sh4r";
            this.Size = new Size(900, 460);
            this.BackColor = Color.FromArgb(12, 12, 12);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // LANGUAGE MENU
            cbLanguage = new ComboBox()
            {
                Location = new Point(15, 15),
                Size = new Size(130, 25),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                Font = new Font("Consolas", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            cbLanguage.Items.AddRange(new string[] { "VI - Tiếng Việt", "EN - English", "ZH - 简体中文", "TW - 繁體中文", "RU - Русский", "KO - 한국어", "JA - 日本語" });
            cbLanguage.SelectedIndex = 0;
            cbLanguage.SelectedIndexChanged += CbLanguage_SelectedIndexChanged;

            // System log console (Simulated)
            txtConsole = new RichTextBox()
            {
                Location = new Point(15, 50),
                Size = new Size(500, 355),
                BackColor = Color.FromArgb(5, 5, 5),
                ForeColor = Color.Lime,
                Font = new Font("Consolas", 8),
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                ScrollBars = RichTextBoxScrollBars.Vertical,
                Text = "SYSTEM TERMINAL\n======================================================\n> INITIALIZING KERNEL INTERFACE...\n> ROOT ACCESS: GRANTED.\n"
            };

            Label lblTitle = new Label()
            {
                Text = "AnyFontUnity",
                Location = new Point(530, 20),
                Size = new Size(340, 25),
                ForeColor = Color.Cyan,
                Font = new Font("Consolas", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            txtPath = new TextBox()
            {
                Location = new Point(530, 60),
                Size = new Size(270, 30),
                Font = new Font("Consolas", 10),
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                ReadOnly = true
            };

            btnBrowse = new Button()
            {
                Text = "...",
                Location = new Point(810, 59),
                Size = new Size(60, 25),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnBrowse.Click += BtnBrowse_Click;

            // Step 1: Install the Patch / Loader
            btnStep1_PathHook = new Button()
            {
                Location = new Point(530, 100),
                Size = new Size(340, 45),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.DimGray,
                ForeColor = Color.Black,
                Font = new Font("Consolas", 11, FontStyle.Bold),
                Enabled = false
            };
            btnStep1_PathHook.FlatAppearance.BorderSize = 0;
            btnStep1_PathHook.Click += BtnStep1_PathHook_Click;

            // Step 2: Run the game and monitor the hook status
            btnStep2_RunHook = new Button()
            {
                Location = new Point(530, 160),
                Size = new Size(340, 45),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.DimGray,
                ForeColor = Color.Black,
                Font = new Font("Consolas", 11, FontStyle.Bold),
                Enabled = false
            };
            btnStep2_RunHook.FlatAppearance.BorderSize = 0;
            btnStep2_RunHook.Click += BtnStep2_RunHook_Click;

            // Step 3: Configure the font and load the DLL
            btnStep3_SelectFont = new Button()
            {
                Location = new Point(530, 220),
                Size = new Size(340, 45),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.DimGray,
                ForeColor = Color.Black,
                Font = new Font("Consolas", 11, FontStyle.Bold),
                Enabled = false
            };
            btnStep3_SelectFont.FlatAppearance.BorderSize = 0;
            btnStep3_SelectFont.Click += BtnStep3_SelectFont_Click;

            lblStatus = new Label()
            {
                Location = new Point(530, 280),
                Size = new Size(340, 30),
                ForeColor = Color.SpringGreen,
                Font = new Font("Consolas", 9, FontStyle.Italic),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Discord Server (Được đưa xuống góc dưới bên phải với icon và căn trái)
            Button btnDiscord = new Button()
            {
                Text = " 💬 Discord",
                Location = new Point(530, 340),
                Size = new Size(165, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(20, 20, 20),
                ForeColor = Color.Cyan,
                Font = new Font("Consolas", 9, FontStyle.Bold),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleLeft
            };
            btnDiscord.FlatAppearance.BorderColor = Color.Cyan;
            btnDiscord.Click += (s, ev) => Process.Start(new ProcessStartInfo("https://discord.com/users/1425047328003325992") { UseShellExecute = true });

            // GitHub Server (Được đưa xuống góc dưới bên phải với icon và căn trái)
            Button btnGithub = new Button()
            {
                Text = " 🐙 GitHub",
                Location = new Point(705, 340),
                Size = new Size(165, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(20, 20, 20),
                ForeColor = Color.SpringGreen,
                Font = new Font("Consolas", 9, FontStyle.Bold),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleLeft
            };
            btnGithub.FlatAppearance.BorderColor = Color.SpringGreen;
            btnGithub.Click += (s, ev) => Process.Start(new ProcessStartInfo("https://github.com/xSh4r103") { UseShellExecute = true });

            lblCredit = new Label()
            {
                Location = new Point(530, 385),
                Size = new Size(340, 20),
                ForeColor = Color.DimGray,
                Font = new Font("Consolas", 9),
                TextAlign = ContentAlignment.BottomRight
            };

            // Add components to the form
            this.Controls.Add(cbLanguage);
            this.Controls.Add(txtConsole);
            this.Controls.Add(lblTitle);
            this.Controls.Add(txtPath);
            this.Controls.Add(btnBrowse);
            this.Controls.Add(btnStep1_PathHook);
            this.Controls.Add(btnStep2_RunHook);
            this.Controls.Add(btnStep3_SelectFont);
            this.Controls.Add(lblStatus);
            this.Controls.Add(btnDiscord);
            this.Controls.Add(btnGithub);
            this.Controls.Add(lblCredit);
        }

        // Handle ComboBox language selection change events
        private void CbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] langs = { "VI", "EN", "ZH", "TW", "RU", "KO", "JA" };
            Loc.Current = langs[cbLanguage.SelectedIndex];
            UpdateUITexts();
        }

        // Update all UI text to match the selected language
        private void UpdateUITexts()
        {
            btnStep1_PathHook.Text = Loc.Get(btn1Key);
            btnStep2_RunHook.Text = Loc.Get(btn2Key);
            btnStep3_SelectFont.Text = Loc.Get(btn3Key);
            lblCredit.Text = Loc.Get("Credit");

            if (!string.IsNullOrEmpty(formatParam) && Loc.Get(currentStatusKey).Contains("{0}"))
                lblStatus.Text = string.Format(Loc.Get(currentStatusKey), formatParam);
            else
                lblStatus.Text = Loc.Get(currentStatusKey);
        }

        // Add a command-line message to the emulated console
        private void AppendLog(string message, bool useHex = false)
        {
            string prefix = "> ";
            if (useHex) prefix = $"[0x{rnd.Next(0x100000, 0xFFFFFF):X6}] ";

            txtConsole.AppendText(prefix + message + "\n");
            txtConsole.SelectionStart = txtConsole.Text.Length;
            txtConsole.ScrollToCaret();
        }

        // Handle the button click event to browse for the game executable (.exe)
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Game Executable (*.exe)|*.exe";
                ofd.Title = "Select .exe";
                ofd.DereferenceLinks = true; // Automatically resolve shortcuts (.lnk) to their original .exe files

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string selectedExe = ofd.FileName;
                    string checkFolderPath = Path.GetDirectoryName(selectedExe);

                    string exeName = Path.GetFileNameWithoutExtension(selectedExe);

                    // Check the Data folder per Unity identification standards
                    string dataFolderPath = Path.Combine(checkFolderPath, exeName + "_Data");
                    string unityPlayerPath = Path.Combine(checkFolderPath, "UnityPlayer.dll");
                    string crashHandlerPath = Path.Combine(checkFolderPath, "UnityCrashHandler64.exe");

                    // Verify that the directory contains a valid Unity engine
                    if (Directory.Exists(dataFolderPath) || File.Exists(unityPlayerPath) || File.Exists(crashHandlerPath))
                    {
                        gameFolderPath = checkFolderPath;
                        gameExePath = selectedExe;

                        txtPath.Text = Path.GetFileName(selectedExe);

                        AppendLog($"[SYSTEM] TARGET EXECUTABLE LOCKED: {Path.GetFileName(selectedExe)}");
                        AppendLog($"[SYSTEM] UNITY ENGINE DETECTED IN: {gameFolderPath}");

                        EnableButton(btnStep1_PathHook, Color.Cyan, "Btn1_Ready");
                        currentStatusKey = "Status_ValidExe";
                        UpdateUITexts();
                    }
                    else
                    {
                        AppendLog("[ERROR] INVALID TARGET! NO UNITY ENGINE FILES DETECTED.");
                        MessageBox.Show(Loc.Get("Msg_InvalidTarget"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        DisableButton(btnStep1_PathHook, "Btn1_Default");
                        currentStatusKey = "Status_InvalidExe";
                        UpdateUITexts();
                    }
                }
            }
        }

        // Handle button-click event for Step 1: Install the patch/loader
        private void BtnStep1_PathHook_Click(object sender, EventArgs e)
        {
            using (VersionSelectorForm vsf = new VersionSelectorForm())
            {
                if (vsf.ShowDialog(this) == DialogResult.OK)
                {
                    string selectedVersion = vsf.SelectedVersion;
                    formatParam = selectedVersion;

                    AppendLog($"[STEP 1] TARGET VERSION SELECTED: {selectedVersion}");
                    AppendLog("[STEP 1] EXTRACTING AND INJECTING CORE FRAMEWORK...");

                    currentStatusKey = "Status_Patching";
                    UpdateUITexts();
                    Application.DoEvents();

                    try
                    {
                        string resourceName = $"AnyFontUnity.melon_{selectedVersion}.zip";
                        Assembly assembly = Assembly.GetExecutingAssembly();

                        // Read compressed embedded resources within the application
                        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                        {
                            if (stream == null) throw new Exception("Resource not found!");
                            using (ZipArchive archive = new ZipArchive(stream))
                            {
                                foreach (ZipArchiveEntry entry in archive.Entries)
                                {
                                    string destPath = Path.Combine(gameFolderPath, entry.FullName);
                                    if (string.IsNullOrEmpty(entry.Name)) Directory.CreateDirectory(destPath);
                                    else
                                    {
                                        Directory.CreateDirectory(Path.GetDirectoryName(destPath));
                                        entry.ExtractToFile(destPath, true);
                                    }
                                }
                            }
                        }

                        AppendLog("[STEP 1] CORE FRAMEWORK INJECTED SUCCESSFULLY!");

                        DisableButton(btnStep1_PathHook, "Btn1_Done");
                        EnableButton(btnStep2_RunHook, Color.Cyan, "Btn2_Ready");

                        currentStatusKey = "Status_WaitRun";
                        UpdateUITexts();
                    }
                    catch (Exception ex)
                    {
                        AppendLog($"[ERROR] INJECTION FAILED: {ex.Message}");
                        MessageBox.Show(Loc.Get("Msg_ExtractError") + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        currentStatusKey = "Status_PatchFail";
                        UpdateUITexts();
                    }
                }
                else
                {
                    AppendLog("[STEP 1] VERSION SELECTION CANCELED.");
                }
            }
        }

        // Handle button-click event for Step 2: Run the game and monitor the system log to execute the hook
        private async void BtnStep2_RunHook_Click(object sender, EventArgs e)
        {
            DialogResult diag = MessageBox.Show(Loc.Get("Msg_HookInstruct"), "Hook", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (diag == DialogResult.Cancel)
            {
                AppendLog("[STEP 2] HOOK PROCESS CANCELED BY USER.");
                return;
            }

            AppendLog("[STEP 2] STARTING GAME & MONITORING LOG...");

            currentStatusKey = "Status_EngineStart";
            DisableButton(btnStep2_RunHook, "Btn2_Watch");
            UpdateUITexts();

            try
            {
                Process gameProcess = new Process();
                gameProcess.StartInfo.FileName = gameExePath;
                gameProcess.StartInfo.WorkingDirectory = gameFolderPath;
                gameProcess.StartInfo.UseShellExecute = true;
                gameProcess.StartInfo.Verb = "runas";
                gameProcess.Start();

                AppendLog($"[SYSTEM] PROCESS CALLED. WAITING FOR LOG GENERATION...");
                currentStatusKey = "Status_WaitLog";
                UpdateUITexts();

                string logFilePath = Path.Combine(gameFolderPath, "MelonLoader", "Latest.log");
                string targetString = "Registered mono icall UnityEngine.Transform::SetAsLastSibling in il2cpp domain";
                bool successHook = false;

                int waitLogCount = 0;
                while (!File.Exists(logFilePath))
                {
                    await Task.Delay(1000);
                    waitLogCount++;
                    if (waitLogCount > 180) throw new Exception(Loc.Get("Msg_LogTimeout"));
                }

                DateTime startTime = DateTime.Now;
                using (FileStream fs = new FileStream(logFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (true)
                    {
                        if ((DateTime.Now - startTime).TotalSeconds > 300) throw new Exception(Loc.Get("Msg_HookTimeout"));

                        string line;
                        while ((line = await sr.ReadLineAsync()) != null)
                        {
                            string displayLine = line.Replace("MelonLoader", "CORE_FRAMEWORK").Replace("Melon", "CORE");
                            if (!string.IsNullOrWhiteSpace(displayLine))
                            {
                                if (displayLine.Length > 85) displayLine = displayLine.Substring(0, 85) + "...";
                                AppendLog(displayLine, true);
                            }

                            if (line.Contains(targetString))
                            {
                                successHook = true;
                                break;
                            }
                        }

                        if (successHook) break;
                        await Task.Delay(500);
                    }
                }

                if (successHook)
                {
                    AppendLog("[SYSTEM] IL2CPP DOMAIN REGISTERED! TARGET ACQUIRED.");
                    AppendLog("[STEP 2] HOOK SUCCESSFUL. KERNEL PREPARED.");

                    currentStatusKey = "Status_HookSuccess";
                    DisableButton(btnStep2_RunHook, "Btn2_Done");
                    EnableButton(btnStep3_SelectFont, Color.SpringGreen, "Btn3_Ready");
                    UpdateUITexts();
                }
            }
            catch (Exception ex)
            {
                AppendLog($"[ERROR] HOOK FAILED: {ex.Message}");
                MessageBox.Show(Loc.Get("Msg_HookError") + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                EnableButton(btnStep2_RunHook, Color.Cyan, "Btn2_Retry");
                currentStatusKey = "Status_HookFail";
                UpdateUITexts();
            }
        }

        // Handle button-click event for Step 3: Configure and inject the DLL and font into the game
        private void BtnStep3_SelectFont_Click(object sender, EventArgs e)
        {
            using (FontConfigForm fcf = new FontConfigForm())
            {
                if (fcf.ShowDialog(this) == DialogResult.OK)
                {
                    AppendLog("[STEP 3] INITIATING DLL & FONT INJECTION...");
                    currentStatusKey = "Status_Injecting";
                    UpdateUITexts();
                    Application.DoEvents();

                    try
                    {
                        string modsDir = Path.Combine(gameFolderPath, "Mods");
                        Directory.CreateDirectory(modsDir);

                        string dllLogName = fcf.SelectedDllZip.Contains("IL2CPP") ? "GlobalTMPFontFixIL2CPP.dll" : "GlobalTMPFontFixMONO.dll";
                        AppendLog($"[STEP 3] DEPLOYING CORE MODULE: {dllLogName}");

                        ExtractZipToMods(fcf.SelectedDllZip, modsDir);

                        if (fcf.UseSystemFont)
                        {
                            AppendLog("[STEP 3] DEPLOYING SYSTEM FONT (ALL LANGUAGES SUPPORTED)...");
                            ExtractZipToMods("AnyFontUnity.GlobalTMPFont.zip", modsDir);
                        }
                        else
                        {
                            AppendLog($"[STEP 3] DEPLOYING CUSTOM FONT: {Path.GetFileName(fcf.CustomFontPath)}");
                            string destFontPath = Path.Combine(modsDir, "GlobalTMPFont.ttf");
                            File.Copy(fcf.CustomFontPath, destFontPath, true);
                            AppendLog("[SYSTEM] CUSTOM FONT RENAMED TO: GlobalTMPFont.ttf");
                        }

                        AppendLog("[STEP 3] ALL PROCESSES COMPLETED.");

                        currentStatusKey = "Status_AllDone";
                        DisableButton(btnStep3_SelectFont, "Btn3_Done");
                        UpdateUITexts();

                        MessageBox.Show(Loc.Get("Msg_Done"), "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        AppendLog($"[ERROR] INJECTION FAILED: {ex.Message}");
                        MessageBox.Show(Loc.Get("Msg_ExtractError") + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        currentStatusKey = "Status_InjectFail";
                        UpdateUITexts();
                    }
                }
                else
                {
                    AppendLog("[STEP 3] FONT CONFIGURATION CANCELED.");
                }
            }
        }

        // Extract the ZIP file from embedded resources into the game Mods folder
        private void ExtractZipToMods(string resourceName, string targetModsDir)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null) throw new Exception($"Missing resource: {resourceName}");

                using (ZipArchive archive = new ZipArchive(stream))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (!string.IsNullOrEmpty(entry.Name))
                        {
                            string destPath = Path.Combine(targetModsDir, entry.Name);
                            entry.ExtractToFile(destPath, true);
                        }
                    }
                }
            }
        }

        // Enable the button, and change its color and cursor
        private void EnableButton(Button btn, Color color, string locKey)
        {
            btn.Enabled = true;
            btn.BackColor = color;
            btn.Cursor = Cursors.Hand;
            if (btn == btnStep1_PathHook) btn1Key = locKey;
            if (btn == btnStep2_RunHook) btn2Key = locKey;
            if (btn == btnStep3_SelectFont) btn3Key = locKey;
        }

        // Disable the button and gray it out
        private void DisableButton(Button btn, string locKey)
        {
            btn.Enabled = false;
            btn.BackColor = Color.FromArgb(50, 50, 50);
            btn.ForeColor = Color.DarkGray;
            btn.Cursor = Cursors.Default;
            if (btn == btnStep1_PathHook) btn1Key = locKey;
            if (btn == btnStep2_RunHook) btn2Key = locKey;
            if (btn == btnStep3_SelectFont) btn3Key = locKey;
        }
    }

    // A pop-up window allowing users to select a patch version
    public class VersionSelectorForm : Form
    {
        public string SelectedVersion { get; private set; }
        private ComboBox cbVersions;
        private Button btnConfirm;

        public VersionSelectorForm()
        {
            this.Text = "Version";
            this.Size = new Size(350, 190);
            this.BackColor = Color.FromArgb(12, 12, 12);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterParent;

            Label lblTitle = new Label()
            {
                Text = Loc.Get("VS_Title"),
                Location = new Point(10, 15),
                Size = new Size(310, 30),
                ForeColor = Color.Cyan,
                Font = new Font("Consolas", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            cbVersions = new ComboBox()
            {
                Location = new Point(50, 60),
                Size = new Size(235, 30),
                Font = new Font("Consolas", 11),
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Cursor = Cursors.Hand
            };

            cbVersions.Items.AddRange(new string[] { "v0.7.3", "v0.7.2", "v0.6.6" });
            cbVersions.SelectedIndex = 0;

            btnConfirm = new Button()
            {
                Text = Loc.Get("VS_Confirm"),
                Location = new Point(50, 100),
                Size = new Size(235, 35),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.SpringGreen,
                ForeColor = Color.Black,
                Font = new Font("Consolas", 11, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnConfirm.FlatAppearance.BorderSize = 0;

            btnConfirm.Click += (s, e) => {
                SelectedVersion = cbVersions.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            this.Controls.Add(lblTitle);
            this.Controls.Add(cbVersions);
            this.Controls.Add(btnConfirm);
        }
    }

    // DLL and Font Configuration Dialog (Step 3)
    public class FontConfigForm : Form
    {
        public bool UseSystemFont { get; private set; }
        public string CustomFontPath { get; private set; }
        public string SelectedDllZip { get; private set; }

        public FontConfigForm()
        {
            this.Text = "Config";
            this.Size = new Size(600, 250);
            this.BackColor = Color.FromArgb(12, 12, 12);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterParent;

            Label lblDllTitle = new Label()
            {
                Text = Loc.Get("FC_Title"),
                Location = new Point(20, 20),
                Size = new Size(230, 20),
                ForeColor = Color.Cyan,
                Font = new Font("Consolas", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            ComboBox cbDll = new ComboBox()
            {
                Location = new Point(20, 55),
                Size = new Size(230, 30),
                Font = new Font("Consolas", 11),
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Cursor = Cursors.Hand
            };
            cbDll.Items.Add("IL2CPP");
            cbDll.Items.Add("MONO");
            cbDll.SelectedIndex = 0;

            Label lblDllNote = new Label()
            {
                Text = Loc.Get("FC_DllNote"),
                Location = new Point(20, 95),
                Size = new Size(230, 40),
                ForeColor = Color.SpringGreen,
                Font = new Font("Consolas", 9, FontStyle.Italic),
                TextAlign = ContentAlignment.TopCenter
            };

            Label lblLine = new Label()
            {
                Location = new Point(275, 20),
                Size = new Size(1, 160),
                BackColor = Color.FromArgb(40, 40, 40)
            };

            Label lblFontTitle = new Label()
            {
                Text = Loc.Get("FC_FontTitle"),
                Location = new Point(300, 20),
                Size = new Size(260, 20),
                ForeColor = Color.Cyan,
                Font = new Font("Consolas", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblFontDesc = new Label()
            {
                Text = Loc.Get("FC_FontDesc"),
                Location = new Point(290, 55),
                Size = new Size(280, 70),
                ForeColor = Color.LightGray,
                Font = new Font("Consolas", 9),
                TextAlign = ContentAlignment.TopCenter
            };

            Button btnSystemFont = new Button()
            {
                Text = Loc.Get("FC_SysFont"),
                Location = new Point(295, 135),
                Size = new Size(130, 45),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.SpringGreen,
                ForeColor = Color.Black,
                Font = new Font("Consolas", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSystemFont.FlatAppearance.BorderSize = 0;
            btnSystemFont.Click += (s, e) => {
                SelectedDllZip = cbDll.SelectedIndex == 0 ? "AnyFontUnity.GlobalTMPFontFixIL2CPP.zip" : "AnyFontUnity.GlobalTMPFontFixMONO.zip";
                UseSystemFont = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            Button btnCustomFont = new Button()
            {
                Text = Loc.Get("FC_CustomFont"),
                Location = new Point(435, 135),
                Size = new Size(130, 45),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Cyan,
                ForeColor = Color.Black,
                Font = new Font("Consolas", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCustomFont.FlatAppearance.BorderSize = 0;
            btnCustomFont.Click += (s, e) => {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "TrueType Font (*.ttf)|*.ttf";
                    ofd.Title = "Select .ttf";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        SelectedDllZip = cbDll.SelectedIndex == 0 ? "AnyFontUnity.GlobalTMPFontFixIL2CPP.zip" : "AnyFontUnity.GlobalTMPFontFixMONO.zip";
                        UseSystemFont = false;
                        CustomFontPath = ofd.FileName;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            };

            this.Controls.Add(lblDllTitle);
            this.Controls.Add(cbDll);
            this.Controls.Add(lblDllNote);
            this.Controls.Add(lblLine);
            this.Controls.Add(lblFontTitle);
            this.Controls.Add(lblFontDesc);
            this.Controls.Add(btnSystemFont);
            this.Controls.Add(btnCustomFont);
        }
    }
}
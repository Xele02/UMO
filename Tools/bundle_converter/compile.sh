pyinstaller --onedir \
--collect-all UnityPy \
--collect-all fmod_toolkit \
--collect-all archspec \
patch_stream.py

pyinstaller --onedir \
--collect-all UnityPy \
--collect-all fmod_toolkit \
--collect-all archspec \
patch_service.py

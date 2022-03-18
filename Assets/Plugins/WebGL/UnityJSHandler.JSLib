mergeInto(LibraryManager.library, {
  ExitGame: function (stringValue) {
    window.ReactNativeWebView.postMessage(
      "exitGame",
      Pointer_stringify(stringValue)
    );
  },
});
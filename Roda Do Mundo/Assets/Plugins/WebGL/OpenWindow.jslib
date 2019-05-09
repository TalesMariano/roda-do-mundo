var OpenWindowPlugin = {
    openWindow: function(link)
    {
    	var url = Pointer_stringify(link);
        document.onmouseup = function()
        {
        	window.open(url);
        	document.onmouseup = null;
            document.onkeyup = null;
        }
        document.onkeyup = function()
        {
        	window.open(url);
        	document.onmouseup = null;
            document.onkeyup = null;
        }
    }
};

mergeInto(LibraryManager.library, OpenWindowPlugin);
﻿//estava de bobeira no main da masterpage


    function bookmark(url, title) {
        if (window.sidebar) { // firefox
            window.sidebar.addPanel(title, url, "");
        } else if (window.opera && window.print) { // opera
            var elem = document.createElement('a');
            elem.setAttribute('href', url);
            elem.setAttribute('title', title);
            elem.setAttribute('rel', 'sidebar');
            elem.click();
        } else if (document.all) {// ie
            window.external.AddFavorite(url, title);
        }
    }
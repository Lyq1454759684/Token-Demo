!(function (window) {
    var functions = {
        sendAjaxRequest: function (opts) {
            var self = this;
            $.ajax({
                type: opts.type || "post",
                url: opts.url,
                data: opts.param || {},              
                beforeSend: function (XMLHttpRequest) {                    
                    XMLHttpRequest.setRequestHeader(LYQ.getAuthorizationKey(), "");
                },
                dataType: opts.dataType || "json",
                success: function (result) {                    
                    if (Object.prototype.toString.call(opts.callBack) === "[object Function]") {   //判断callback 是否是 function               
                        opts.callBack(result);
                    } else {
                        console.log("CallBack is not a function");
                    }
                }
            });
        },        
        getRequestHeaderAuthorizationToken: function () {
            var document_cookie = document.cookie;
            //var reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
            //if (document_cookie = document.cookie.match(reg))
            //    return unescape(arr[2]);
            //else
            //    return null;
            console.log(document_cookie);
        },
        getAuthorizationKey: function () {
            return 'Authorization';
        }
    };        

    window.LYQ = functions;
})(this);
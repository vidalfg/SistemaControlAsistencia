
var sendServer = function (opts) {

    var urlRaiz = document.getElementById("hdfRaiz").value;
    var urlBase = "https://" + window.location.host + urlRaiz;
    window.localStorage.setItem("urlBase", urlBase)

    var xhr = new XMLHttpRequest;
    return new Promise(function (resolve, reject) {
        xhr.onreadystatechange = function () {
            if (xhr.readyState !== 4) return;
            if (xhr.status >= 200 && xhr.readyState == 4) {
                resolve(xhr);
            } else {
                reject({
                    status: xhr.status,
                    statusText: xhr.statusText
                });
            }
        }
        var params = opts.params;
        if (params && typeof params === 'object') {
            opts.method = "POST";
            params = Object.keys(params).map(function (key) {
                return encodeURIComponent(params);
            }).join('&');
        }

        xhr.open(opts.method || 'GET', urlBase + opts.url, true);
        xhr.send(params)
    });
}


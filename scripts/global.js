// Blazor interop
window.resized = () => {
    window.dispatchEvent(new Event('resize'));
};

window.log = text => {
    console.log(text);
};

window.changeTheme = theme => {
    setTheme(theme);
};

// Theme
var appTheme = "auto";

const setTheme = theme => {
    appTheme = theme;
    switch (theme) {
        case "auto":
            return setDefaultTheme();
        case "light":
            document.body.className = "body-light";
            return "light";
        case "dark":
            document.body.className = "body-dark";
            return "dark";
    }
};

const setDefaultTheme = () => {
    if (
        window.matchMedia &&
        window.matchMedia("(prefers-color-scheme: dark)").matches
    ) {
        document.body.className = "body-dark";
        return "dark";
    } else {
        document.body.className = "body-light";
        return "light";
    }
};

const query = window.matchMedia("(prefers-color-scheme: dark)");
query.addListener(() => {
    if (appTheme === "auto") {
        setDefaultTheme();
    }
});

setDefaultTheme();

// Notification
const applicationServerPublicKey = 'BLC8GOevpcpjQiLkO7JmVClQjycvTCYWm6Cq_a7wJZlstGTVZvwGFFHMYfXt6Njyvgx_GlXJeo5cSiZ1y4JOx1o';

window.blazorPushNotifications = {
    requestSubscription: async () => {
        const worker = await navigator.serviceWorker.getRegistration();
        const existingSubscription = await worker.pushManager.getSubscription();
        if (!existingSubscription) {
            const newSubscription = await subscribe(worker);
            if (newSubscription) {
                return {
                    url: newSubscription.endpoint,
                    p256dh: arrayBufferToBase64(newSubscription.getKey('p256dh')),
                    auth: arrayBufferToBase64(newSubscription.getKey('auth'))
                };
            }
        }
    }
};

async function subscribe(worker) {
    try {
        return await worker.pushManager.subscribe({
            userVisibleOnly: true,
            applicationServerKey: applicationServerPublicKey
        });
    } catch (error) {
        if (error.name === 'NotAllowedError') {
            return null;
        }
        throw error;
    }
}

function arrayBufferToBase64(buffer) {
    // https://stackoverflow.com/a/9458996
    var binary = '';
    var bytes = new Uint8Array(buffer);
    var len = bytes.byteLength;
    for (var i = 0; i < len; i++) {
        binary += String.fromCharCode(bytes[i]);
    }
    return window.btoa(binary);
}

// Syncfusion
window.sfBlazor = { getCharCollectionSize: function (t) { for (var e = [], i = this.getAllCharacters(), n = i.length, l = t.length, o = 0; o < l; o++) { for (var r = t[o].split("_"), s = r[0], h = r[1], a = r[2], f = {}, g = 0; g < n; g++)f[i[g]] = this.measureText(i[g], s, h, a); e.push(f) } return JSON.stringify(e) }, getCharSizeByFontKeys: function (t) { for (var e = {}, i = [], n = t.length, l = 0; l < n; l++)i = t[l].split("_"), e[t[l]] = this.measureText(i[0], i[1], i[2], i[3]); return JSON.stringify(e) }, getElementBoundsById: function (t) { var e, i, n = document.getElementById(t), l = document.getElementById(t + "_svg"); if (n) { l && (l.style.display = "none"), n.style.width = "100%", n.style.height = "100%"; var o = n.getBoundingClientRect(); return e = n.clientWidth || n.offsetWidth, i = n.clientHeight || n.offsetHeight, l && (l.style.display = ""), { width: e, height: i, left: o.left, top: o.top, right: o.right, bottom: o.bottom } } return { width: 0, height: 0, left: 0, top: 0, right: 0, bottom: 0 } }, charCollection: [], getAllCharacters: function () { if (!this.charCollection.length) { for (var t = [], e = 33; e < 591; e++)t.push(String.fromCharCode(e)); this.charCollection = t } return this.charCollection }, measureText: function (t, e, i, n) { var l = document.getElementById("sfblazor_measuretext"); return null === l && ((l = document.createElement("text")).id = "sfblazor_measuretext", document.body.appendChild(l)), " " === t && (t = "&nbsp;"), l.innerHTML = t, l.style.position = "fixed", l.style.fontSize = "100px", l.style.fontWeight = e, l.style.fontStyle = i, l.style.fontFamily = n, l.style.visibility = "hidden", l.style.top = "-100", l.style.left = "0", l.style.whiteSpace = "nowrap", l.style.lineHeight = "normal", { X: l.clientWidth, Y: l.clientHeight } }, setSvgDimensions: function (t, e, i) { t.setAttribute("width", e), t.setAttribute("height", i) } };
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
    var binary = '';
    var bytes = new Uint8Array(buffer);
    var len = bytes.byteLength;
    for (var i = 0; i < len; i++) {
        binary += String.fromCharCode(bytes[i]);
    }
    return window.btoa(binary);
}
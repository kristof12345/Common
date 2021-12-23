window.resized = () => {
    window.dispatchEvent(new Event('resize'));
};

var appTheme = "auto";

const setTheme = type => {
    switch (type) {
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

// Call if OS theme setting changes
const query = window.matchMedia("(prefers-color-scheme: dark)");
query.addListener(() => {
    if (appTheme === "auto") {
        setDefaultTheme();
    }
});

// Call if the user selected theme changes
window.changeTheme = theme => {
    appTheme = theme;
    let selected = setTheme(theme);
    return selected;
};

setDefaultTheme();
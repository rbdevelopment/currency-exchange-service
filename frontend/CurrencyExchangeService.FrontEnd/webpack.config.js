const path = require("path");

module.exports = {
    entry: ["./React/index.jsx"],
    output: {
        filename: "bundle.js",
        path: path.resolve(__dirname, "Content/js")
    },
    resolve: {
        extensions: [".json", ".js", ".jsx"]
    },
    module: {
        loaders: [
            {
                test: /\.jsx?$/,
                exclude: /node_modules/,
                loader: "babel-loader",
                query: {
                    presets: ["react", "es2015", "stage-0"]
                }
            }
        ]
    },
    devtool: "source-map"
};
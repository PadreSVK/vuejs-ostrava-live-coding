import Vue from 'vue';


export function apply() {
    Vue.mixin({
        methods: {
            showErrorNotification({ message }) {
                this.$store.dispatch("showError", { message })
            }
        }
    })
}

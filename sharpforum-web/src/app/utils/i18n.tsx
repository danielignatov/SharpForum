import i18n from 'i18next';
import { initReactI18next } from 'react-i18next';
import LanguageDetector from 'i18next-browser-languagedetector';
import Backend from 'i18next-http-backend';
//import { format as formatDate, formatDistance, formatRelative, isDate } from "date-fns";
//import { enGB, bg, fr } from "date-fns/locale";

i18n
    // i18next-http-backend
    // loads translations from your server
    // https://github.com/i18next/i18next-http-backend
    .use(Backend)
    // detect user language
    // learn more: https://github.com/i18next/i18next-browser-languageDetector
    .use(LanguageDetector)
    // pass the i18n instance to react-i18next.
    .use(initReactI18next)
    // init i18next
    // for all options read: https://www.i18next.com/overview/configuration-options
    .init({
        debug: false, // Console logs
        fallbackLng: 'en',
        interpolation: {
            escapeValue: false, // not needed for react as it escapes by default
            //format: function (value, format: any, lng) {
            //    if (lng && isDate(value)) {
            //        let locale: Locale = enGB;
            //
            //        switch (lng) {
            //            case 'bg': {
            //                locale = bg;
            //                break;
            //            }
            //            case 'fr': {
            //                locale = fr;
            //                break;
            //            }
            //        };
            //
            //        if (format === "short")
            //            return formatDate(value, "P", { locale });
            //        if (format === "long")
            //            return formatDate(value, "PPPP", { locale });
            //        if (format === "relative")
            //            return formatRelative(value, new Date(), { locale });
            //        if (format === "ago")
            //            return formatDistance(value, new Date(), {
            //                locale,
            //                addSuffix: true
            //            });
            //
            //        return formatDate(value, format, { locale });
            //    }
            //    return value;
            //}
        },
        backend: {
            // for all available options read the backend's repository readme file
            loadPath: '/locales/{{lng}}.json',
            crossDomain: false
        },
        react: {
            useSuspense: true
        },
        detection: {
            lookupLocalStorage: 'locale'
        }
    });

export default i18n;
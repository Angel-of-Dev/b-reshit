import {defineConfig} from 'vitepress'
import inject from '@rollup/plugin-inject';
import katex from 'markdown-it-katex';

// https://vitepress.dev/reference/site-config
export default defineConfig({
  title: "Angel of Dev",
  description: "",
  plugins: [
    inject({
      p5: 'p5',
    })
  ],
  head: [
    ['link', { rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' }],
    // KaTeX, for mathematical notation support in markdown-it.
    ['link', {rel: 'stylesheet', href: 'https://cdnjs.cloudflare.com/ajax/libs/KaTeX/0.5.1/katex.min.css'}]
  ],
  markdown: {
    config: md => {
      md.use(katex)
    }
  },
  appearance: "force-dark",
  themeConfig: {
    nav: [
      { text: '<span style="font-size: 1.2em"><strong>❂</strong>𝖽𝖽𝗅𝗒<strong>𝓢</strong>𝖾𝖾</span>', link: '/oc/' },
      { text: 'b🌱reshit', link: '/bereshit/' }
    ],
    footer: {
      message: '<strong>FOR ETERNAL USE ONLY 📵 DO YOUR SHARE</strong>',
      copyright: '<a href="/license">License</a> / <a href="/refs/#ref-operaaperta">Opera Aperta</a>'
    }
  },
  transformHead({assets}) {
    
    // Preload ttf fonts.
    const fontAsset = assets.find(() => /font-name\.\w+\.ttf/)
    if (fontAsset) {
      return [
        [
          'link',
          {
            rel: 'preload',
            href: fontAsset,
            as: 'font',
            type: 'font/ttf'
          }
        ]
      ]
    }
  }
})

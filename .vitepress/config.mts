import { defineConfig } from 'vitepress'

// https://vitepress.dev/reference/site-config
export default defineConfig({
  title: "Angel of Dev",
  description: "Software Architect",
  head: [
    ['link', { rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' }],
  ],
  themeConfig: {
    // https://vitepress.dev/reference/default-theme-config
    nav: [
      { text: 'Home', link: '/' },
      { text: 'Articles', link: '/articles/how-this-site-was-made/' }
    ],
    sidebar: [
      {
        text: 'Articles',
        items: [
          { text: 'How This Site Was Made', link: '/articles/how-this-site-was-made/' }
        ]
      }
    ],

    socialLinks: [
      { icon: 'github', link: 'https://github.com/Angel-of-Dev' }
    ]
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

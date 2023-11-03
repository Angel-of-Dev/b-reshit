import { defineConfig } from 'vitepress'

// https://vitepress.dev/reference/site-config
export default defineConfig({
  title: "Angel of Dev",
  description: "Software Architect",
  head: [
    ['link', { rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' }],
      
    // clarity.microsoft.com  
    [
      'script',
      {},
      `(function(c,l,a,r,i,t,y){
      c[a]=c[a]||function(){(c[a].q=c[a].q||[]).push(arguments)};
      t=l.createElement(r);t.async=1;t.src="https://www.clarity.ms/tag/"+i;
      y=l.getElementsByTagName(r)[0];y.parentNode.insertBefore(t,y);
      })(window, document, "clarity", "script", "jknkov0edp");`
    ]
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

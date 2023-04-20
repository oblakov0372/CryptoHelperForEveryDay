import React from "react";
import classes from "./Platforms.module.scss";
import Platform from "../../components/platform/Platform";
import { PlatformType } from "../../types/PlatformType";

const platforms: PlatformType[] = [
  {
    imgLink:
      "data:image/jpeg;base64,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",
    link: "https://ru.tradingview.com/gopro/?share_your_love=oblakov_0372",
    title: "Trading View",
    description:
      "TradingView is a powerful platform for financial charting and analysis that provides traders and investors with a wide range of tools and features to help them make informed trading decisions. ",
  },
  {
    imgLink:
      "data:image/png;base64,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",
    link: "https://resonanceholding.com/ru/auth/registration?ref=85a2c49f79464d7795e42cb814d7d370",
    title: "Resonance",
    description:
      "Explore supply and demand in the market with clusters. A cluster is an x-ray of the volume of transactions for each asset in specific price and time ranges. Visualization of order flow and volumetric market profile will enable you to multiply your deposit",
  },
  {
    imgLink:
      "https://public.bnbstatic.com/20190405/eb2349c3-b2f8-4a93-a286-8f86a62ea9d8.png",
    link: "https://accounts.binance.com/register?ref=165150941",
    title: "Binance",
    description:
      "Binance is one of the largest cryptocurrency exchanges in the world, founded in 2017 by Changpeng Zhao. The exchange allows users to buy, sell, and trade a wide range of cryptocurrencies, including Bitcoin, Ethereum, Binance Coin, and many others. Binance offers both spot trading and futures trading, as well as a number of other services and features such as staking, lending, and margin trading.",
  },
  {
    imgLink:
      "data:image/png;base64,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",
    link: "https://www.bybit.com/invite?ref=BNN39J",
    title: "ByBit",
    description:
      "Bybit has gained popularity among traders due to its user-friendly interface, low trading fees, and advanced trading tools. However, it is important to note that trading cryptocurrency derivatives can be high-risk and should be approached with caution, especially when using high leverage. It is always recommended to conduct thorough research and seek professional advice before trading.",
  },
  {
    imgLink:
      "data:image/jpeg;base64,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",
    link: "https://coinmarketcap.com/",
    title: "CoinMarketCap",
    description:
      "CoinMarketCap is a popular website that provides real-time cryptocurrency market data, including prices, market capitalizations, trading volumes, and other metrics for thousands of cryptocurrencies. It was launched in 2013 by Brandon Chez and was acquired by Binance, one of the world's largest cryptocurrency exchanges, in 2020.",
  },
  {
    imgLink:
      "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQaBDQhpcH6VMkMNj7D30FKBuPJS4JHTf1TvUOsMkdlG6PrlyW9Q-jHJHKQwMxyRmQsgck&usqp=CAU",
    link: "https://t.me/CryptoOblakov_0372",
    title: "My Telegram Chanel",
    description:
      "I enjoy sharing fascinating market insights and situations in my personally owned Telegram channel, where I strive to provide unique perspectives and analysis that can be useful to my followers. Through this platform, I aim to keep my audience updated and informed about the latest trends and developments in the financial world, and provide valuable insights into the market that can help them make informed decisions.",
  },
];

const Platforms = () => {
  return (
    <div className={classes.content}>
      {platforms.map((platform: PlatformType, index: number) => (
        <Platform
          imgLink={platform.imgLink}
          link={platform.link}
          title={index + 1 + ". " + platform.title}
          description={platform.description}
        />
      ))}
    </div>
  );
};

export default Platforms;

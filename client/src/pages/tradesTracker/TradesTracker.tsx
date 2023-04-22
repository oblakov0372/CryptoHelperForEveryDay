import React from "react";
import styles from "./TradesTracker.module.scss";
import { Column } from "../../types/Column";
import TradeRow from "../../components/tradeRow/TradeRow";
import { useSelector } from "react-redux";
import { RootState } from "../../redux/store";
import { TradeFutureType } from "../../types/TradeFutureType";

const TradesTracker = () => {
  const { totalEarnedMoney, totalPositivTrades, totalTrades, trades } =
    useSelector((state: RootState) => state.tradeStatistic);
  const tableColumns: Column[] = [
    { name: "Symbol", orderBy: "symbol" },
    { name: "Position Size$", orderBy: "positionSize" },
    { name: "Stop Loss%", orderBy: "stopLossPercent" },
    { name: "Take Profit%", orderBy: "takeProfitPercent" },
    { name: "Earned Money", orderBy: "earnedMoney" },
    { name: "Trading View", orderBy: "symbol" },
  ];
  return (
    <div className={styles.content}>
      <div className={styles.description}>
        <div className={styles.description__text}>
          <div className={styles.title}>
            <h1>Trades Tracker</h1>
          </div>
          <p>
            Record-Keeping: Keeping track of your trades helps you keep a record
            of your investment decisions. This record can help you analyze your
            performance, identify trends, and make better decisions in the
            future.
            <br />
            Learning from mistakes: By tracking your trades, you can learn from
            your mistakes and improve your trading strategy. You can review your
            past trades and identify what went wrong or right and take
            corrective action.
          </p>
        </div>
        <div className={styles.description__img}></div>
      </div>
      <div className={styles.functional}>
        <div className={styles.tableWrapper}>
          <table>
            <thead>
              <tr>
                {tableColumns.map((column: Column, index: number) => (
                  <th key={index}>{column.name}</th>
                ))}
              </tr>
            </thead>
            <tbody>
              {trades.map((trade: TradeFutureType) => (
                <TradeRow
                  id={trade.id}
                  coinName={trade.coinName}
                  positionSize={trade.positionSize}
                  stopLossPercent={trade.stopLossPercent}
                  takeProfitPercent={trade.takeProfitPercent}
                  tradingViewImgLink={trade.tradingViewImgLink}
                  earnedMoney={trade.earnedMoney}
                />
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
};

export default TradesTracker;
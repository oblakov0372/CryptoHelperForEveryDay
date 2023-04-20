import React from "react";
import styles from "./Platform.module.scss";
import { PlatformType } from "../../types/PlatformType";

const Platform: React.FC<PlatformType> = ({
  imgLink,
  title,
  description,
  link,
}) => {
  return (
    <div>
      <div className={styles.platform}>
        <div className={styles.left}>
          <h2 className={styles.title}>{title}</h2>
          <p>{description}</p>
          <a href={link} target="_blank">
            Go to {title.substring(3)}
          </a>
        </div>
        <div className={styles.right}>
          <img width={150} alt="logo" src={imgLink} />
        </div>
      </div>
    </div>
  );
};

export default Platform;
